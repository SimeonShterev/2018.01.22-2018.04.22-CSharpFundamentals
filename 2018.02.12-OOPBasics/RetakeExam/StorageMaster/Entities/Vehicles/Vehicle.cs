using StorageMaster.Constants;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle
    {
		private List<Product> products;

		protected Vehicle(int capacity)
		{
			this.Capacity = capacity;

			this.products = new List<Product>();
		}

		public int Capacity { get; }

		public IReadOnlyCollection<Product> Trunk => this.products;

		public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity ? true : false;

		public bool IsEmpty => this.products.Any() ? false : true;


		public void LoadProduct(Product product)
		{
			if(this.IsFull)
			{
				throw new InvalidOperationException(Consts.FullVehicle);
			}
			this.products.Add(product);
		}

		public Product Unload()
		{
			if(this.IsEmpty)
			{
				throw new InvalidOperationException(Consts.EmptyVehicle);
			}

			Product product = this.products.Last();
			this.products.RemoveAt(this.products.Count - 1);

			return product;
		}
	}
}
