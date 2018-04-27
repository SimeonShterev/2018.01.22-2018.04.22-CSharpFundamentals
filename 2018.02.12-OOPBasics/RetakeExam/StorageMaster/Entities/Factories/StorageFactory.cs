using StorageMaster.Constants;
using StorageMaster.Entities.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Factories
{
    public class StorageFactory
    {
		public Storage CreateStorage(string type, string name)
		{
			switch(type)
			{
				case nameof(AutomatedWarehouse):
					return new AutomatedWarehouse(name);
				case nameof(DistributionCenter):
					return new DistributionCenter(name);
				case nameof(Warehouse):
					return new Warehouse(name);
				default:
					throw new InvalidOperationException(Consts.InvalidStorage);
			}
		}

	}
}
