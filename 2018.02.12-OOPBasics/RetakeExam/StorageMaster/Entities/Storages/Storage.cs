using StorageMaster.Constants;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public class Storage
    {
		private List<Product> products;
		protected Vehicle[] garageSlots;

		protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
		{
			this.Name = name;
			this.Capacity = capacity;
			this.GarageSlots = garageSlots;
			this.garageSlots = vehicles.ToArray();
			this.products = new List<Product>();
		}

		public string Name { get; }

		public int Capacity { get; }

		public int GarageSlots { get; }

		public bool IsFull => this.products.Where(p=>p!=null).Sum(p => p.Weight) >= this.Capacity ? true : false;

		public IReadOnlyCollection<Vehicle> Garage => this.garageSlots;

		public IReadOnlyCollection<Product> Products => this.products;

		public Vehicle GetVehicle(int garageSlot)
		{
			if(garageSlot>=this.garageSlots.Length || garageSlot<0)
			{
				throw new InvalidOperationException(Consts.InvalidGarageSlot);
			}

			if (this.garageSlots[garageSlot] == null)
			{
				throw new InvalidOperationException(Consts.SlotEmpty);
			}

			return this.garageSlots[garageSlot];
		}

		public int SendVehicleTo(int garageSlot, Storage deliveryLocation) /// check logic
		{
			Vehicle vehicle = this.GetVehicle(garageSlot);

			int counter = 0;
			int index = -1;
			foreach (var v in deliveryLocation.Garage)
			{
				if(v==null)
				{
					index = counter;
					break;
				}
				counter++;
			}
			if(index==-1)
			{
				throw new InvalidOperationException(Consts.NoRoom);
			}

			this.garageSlots[garageSlot] = null;
			deliveryLocation.garageSlots[index] = vehicle;
			return index;
		}

		public int UnloadVehicle(int garageSlot)
		{
			if(this.IsFull)
			{
				throw new InvalidOperationException(Consts.FullStorage);
			}

			Vehicle vehicle = this.GetVehicle(garageSlot);

			int unloadedProductsCounter = 0;
			while(true)
			{
				if(vehicle.IsEmpty || this.IsFull)
				{
					break;
				}

				this.products.Add(vehicle.Unload());
				unloadedProductsCounter++;
			}

			return unloadedProductsCounter;
		}
	}
}
