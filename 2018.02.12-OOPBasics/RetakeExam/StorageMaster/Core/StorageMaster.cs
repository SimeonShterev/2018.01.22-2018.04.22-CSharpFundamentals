using StorageMaster.Constants;
using StorageMaster.Entities.Factories;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
	public class StorageMaster
	{
		private StorageFactory storageFactory;
		//private VehicleFactory vehicleFactory;
		private ProductFactory productFactory;

		private List<Product> products;
		private List<Storage> storages;
		//private List<Vehicle> vehicles;

		private Vehicle currentVehicle;

		public StorageMaster()
		{
			this.products = new List<Product>();
			this.storages = new List<Storage>();


			this.storageFactory = new StorageFactory();
			//this.vehicleFactory = new VehicleFactory();
			this.productFactory = new ProductFactory();

			this.currentVehicle = null;
		}

		public string AddProduct(string type, double price)
		{
			Product product = this.productFactory.CreateProduct(type, price);
			this.products.Add(product);

			return string.Format(Consts.AddedProduct, type);
		}

		public string RegisterStorage(string type, string name)
		{
			Storage storage = this.storageFactory.CreateStorage(type, name);
			this.storages.Add(storage);

			return string.Format(Consts.RegisteredStorage, name);

		}

		public string SelectVehicle(string storageName, int garageSlot)
		{
			this.currentVehicle = this.storages.First(s => s.Name == storageName).GetVehicle(garageSlot);

			return string.Format(Consts.SelectedVehicle, this.currentVehicle.GetType().Name);

		}

		public string LoadVehicle(IEnumerable<string> productNames)
		{
			int loadedProductsCount = 0;
			foreach (var productName in productNames)
			{
				Product product = this.products.LastOrDefault(p => p.GetType().Name == productName);
				if (product == null)
				{
					throw new InvalidOperationException(string.Format(Consts.OutOfStock, productName));
				}
				int lastProductIndex = this.products.LastIndexOf(product);
				this.products.RemoveAt(lastProductIndex);

				if (this.currentVehicle.IsFull)
				{
					break;
				}
				this.currentVehicle.LoadProduct(product);// check if vehicle is full// done
				loadedProductsCount++;
			}

			return string.Format(Consts.ProductsLoaded, loadedProductsCount.ToString(), productNames.Count().ToString(), this.currentVehicle.GetType().Name);
		}

		public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
		{
			Storage source = this.storages.FirstOrDefault(s => s.Name == sourceName);
			if (source == null)
			{
				throw new InvalidOperationException(Consts.InvalidSource);
			}

			Storage destination = this.storages.FirstOrDefault(s => s.Name == destinationName);
			if (destination == null)
			{
				throw new InvalidOperationException(Consts.InvalidDest);
			}

			int destinationGarageSlot = source.SendVehicleTo(sourceGarageSlot, destination);

			return string.Format(Consts.SendVehicleTo, this.currentVehicle.GetType().Name, destinationName, destinationGarageSlot);
		}

		public string UnloadVehicle(string storageName, int garageSlot)
		{
			Storage storage = this.storages.FirstOrDefault(s => s.Name == storageName);
			if (storage == null)
			{
				throw new InvalidOperationException(Consts.InvalidSource);
			}

			int productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;
			int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

			return string.Format(Consts.Unloaded, unloadedProductsCount, productsInVehicle, storageName);
		}

		public string GetStorageStatus(string storageName)
		{
			Storage storage = this.storages.FirstOrDefault(s => s.Name == storageName);
			if (storage == null)
			{
				throw new InvalidOperationException(Consts.InvalidSource);
			}
			StringBuilder builder = new StringBuilder();

			Dictionary<string, int> productsInfo = new Dictionary<string, int>();
			foreach (var prod in storage.Products)
			{
				string prodName = prod.ToString();
				if(!productsInfo.ContainsKey(prodName))
				{
					productsInfo.Add(prodName, 1);
				}
				else
				{
					productsInfo[prodName]++;
				}
			}

			int counter = 1;
			StringBuilder prodInfo = new StringBuilder();
			foreach (var item in productsInfo.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
			{
				if(counter!=1)
				{
					prodInfo.Append(", ");
				}
				prodInfo.Append($"{item.Key} ({item.Value})");

				counter++;
			}

			builder.AppendLine($"Stock ({storage.Products.Sum(p => p.Weight)}/{storage.Capacity}): [{prodInfo}]");

			builder.AppendLine($"Garage: [{string.Join("|", storage.Garage.Select(v=>v==null?"empty":v.ToString()))}]");

			return builder.ToString().Trim();
		}

		public string GetSummary()
		{
			StringBuilder builder = new StringBuilder();
			foreach (var storage in this.storages.OrderByDescending(s => s.Products.Sum(p => p.Price)))
			{
				builder.AppendLine($"{storage.Name}:");
				builder.AppendLine($"Storage worth: ${storage.Products.Sum(p => p.Price):F2}");
			}

			return builder.ToString().Trim();
		}
	}
}
