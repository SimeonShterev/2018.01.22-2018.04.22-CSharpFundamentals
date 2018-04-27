using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    public abstract class Product
    {
		protected Product(double price, double weight)
		{
			this.Price = price;
			this.Weight = weight;
		}

		public double Price { get; }

		public double Weight { get; }
	}
}
