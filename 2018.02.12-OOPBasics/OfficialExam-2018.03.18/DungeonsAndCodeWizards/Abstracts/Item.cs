using DungeonsAndCodeWizards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Abstracts
{
    public abstract class Item : IItem
    {
		protected Item(int weight)
		{
			this.Weight = weight;
		}

		public int Weight { get; }

		public abstract string Name { get; }

		public abstract void AffectCharacter(Character character);
	}
}
