using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Entities.Sets
{
	public class Long : Set
	{
		private TimeSpan defaultMaxDuration;

		public Long(string name)
			: base(name)
		{
			this.defaultMaxDuration = new TimeSpan(0, 60, 0);
		}

		public override TimeSpan MaxDuration => this.defaultMaxDuration;
	}
}
