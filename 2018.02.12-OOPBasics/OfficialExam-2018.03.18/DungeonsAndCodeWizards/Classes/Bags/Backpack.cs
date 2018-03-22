using DungeonsAndCodeWizards.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Classes.Bags
{
	public class Backpack : Bag
	{
		private const int WeightOfBackpack = 100;

		public Backpack()
			: base(WeightOfBackpack)
		{
		}
	}
}
