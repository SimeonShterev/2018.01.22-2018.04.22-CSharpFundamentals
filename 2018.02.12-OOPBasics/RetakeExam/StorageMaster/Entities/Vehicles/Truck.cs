using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
	public class Truck : Vehicle
	{
		public Truck()
			: base(5) { }

		public override string ToString()
		{
			return nameof(Truck);
		}
	}
}
