namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
		private TimeSpan defaultMaxDuration;

		public Medium(string name)
			: base(name)
		{
			this.defaultMaxDuration = new TimeSpan(0, 40, 0);
		}

		public override TimeSpan MaxDuration => this.defaultMaxDuration;
	}
}