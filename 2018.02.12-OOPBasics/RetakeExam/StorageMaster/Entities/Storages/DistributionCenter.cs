using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
	public class DistributionCenter : Storage
	{
		public DistributionCenter(string name)
			: base(name, 2, 5, new Vehicle[5] { new Van(), new Van(), new Van(), null, null })
		{
		}
	}
}
