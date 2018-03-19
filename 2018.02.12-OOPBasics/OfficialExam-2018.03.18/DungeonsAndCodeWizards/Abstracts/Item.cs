using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Abstracts
{
	public abstract class Item
	{
		protected Item(int weight)
		{
			this.Weight = weight;
		}

		public int Weight { get; }

		public virtual void AffectCharacter(Character character)
		{
			if(!character.IsAlive)
			{
				throw new InvalidOperationException(ErrorMessages.Dead);
			}
		}

		public abstract string Name { get; }
	}
}
