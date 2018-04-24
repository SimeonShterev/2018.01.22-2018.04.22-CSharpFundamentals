namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
		private TimeSpan defaultMaxDuration;

		public Short(string name)
			: base(name)
		{
			this.defaultMaxDuration = new TimeSpan(0, 15, 0);
		}

		public override TimeSpan MaxDuration => this.defaultMaxDuration;
	}
}