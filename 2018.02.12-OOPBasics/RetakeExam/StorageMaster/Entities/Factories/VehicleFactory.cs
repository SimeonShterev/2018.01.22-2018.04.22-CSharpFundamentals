using StorageMaster.Constants;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Factories
{
	public class VehicleFactory
	{
		public Vehicle CreateVehicle(string type)
		{
			switch (type)
			{
				case nameof(Semi):
					return new Semi();
				case nameof(Van):
					return new Van();
				case nameof(Truck):
					return new Truck();
				default:
					throw new InvalidCastException(Consts.InvalidVehicle);
			}
		}

	}
}
