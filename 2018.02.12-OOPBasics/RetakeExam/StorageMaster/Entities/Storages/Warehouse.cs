using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
	public class Warehouse : Storage
	{
		public Warehouse(string name)
			: base(name, 10, 10, new Vehicle[10] { new Semi(), new Semi(), new Semi(), null, null, null, null, null, null, null })
		{
		}
	}
}
