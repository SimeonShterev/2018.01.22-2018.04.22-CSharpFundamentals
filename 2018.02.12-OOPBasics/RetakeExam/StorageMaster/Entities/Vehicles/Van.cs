using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
	public class Van : Vehicle
	{
		public Van()
			: base(2) { }

		public override string ToString()
		{
			return nameof(Van);
		}
	}
}
