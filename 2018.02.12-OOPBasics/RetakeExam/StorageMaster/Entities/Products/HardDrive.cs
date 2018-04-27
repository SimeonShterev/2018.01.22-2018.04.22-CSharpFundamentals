using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
	public class HardDrive : Product
	{
		public HardDrive(double price)
			: base(price, 1d) { }

		public override string ToString()
		{
			return nameof(HardDrive);
		}
	}
}
