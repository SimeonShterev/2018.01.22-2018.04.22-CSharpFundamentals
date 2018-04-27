using StorageMaster.Constants;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Factories
{
    public class ProductFactory
    {
		public Product CreateProduct(string type, double price)
		{
			if(price<=0)
			{
				throw new InvalidOperationException(Consts.NegativePrice);
			}
			switch(type)
			{
				case nameof(Gpu):
					return new Gpu(price);
				case nameof(HardDrive):
					return new HardDrive(price);
				case nameof(Ram):
					return new Ram(price);
				case nameof(SolidStateDrive):
					return new SolidStateDrive(price);
				default:
					throw new InvalidOperationException(Consts.InvalidProduct);
			}
		}

	}
}
