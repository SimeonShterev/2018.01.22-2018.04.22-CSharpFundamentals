using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
	public class Robot : Worker, IRechargeable
	{
		private int currentPower;

		public Robot(string id, int capacity) : base(id)
		{
			this.Capacity = capacity;
		}

		public int Capacity { get; }

		public int CurrentPower
		{
			get { return this.currentPower; }
			set { this.currentPower = value; }
		}

		public override void Work(int hours)
		{
			if (hours > this.currentPower)
			{
				hours = currentPower;
			}

			base.Work(hours);
			this.currentPower -= hours;
		}

		public void Recharge()
		{
			this.currentPower = this.Capacity;
		}
	}
}