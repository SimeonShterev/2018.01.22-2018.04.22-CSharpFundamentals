using DungeonsAndCodeWizards.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Classes.Bags
{
	public class Satchel : Bag
	{
		private const int WeightOfSetchel = 20;

		public Satchel() 
			: base(WeightOfSetchel)
		{
		}
	}
}
