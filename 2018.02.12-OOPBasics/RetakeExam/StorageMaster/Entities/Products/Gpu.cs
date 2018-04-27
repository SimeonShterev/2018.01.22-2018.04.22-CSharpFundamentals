using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
	public class Gpu : Product
	{
		public Gpu(double price)
			: base(price, 0.7) { }

		public override string ToString()
		{
			return nameof(Gpu);
		}
	}
}
