using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Classes.Bags;
using DungeonsAndCodeWizards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Classes.Characters
{
	public class Cleric : Character, IHealable
	{
		private double health;

		private double armor;

		public Cleric(string name, Faction faction)
			: base(name, 50d, 25d, 40d, new Backpack(), faction)
		{
			this.RestHealMultiplier = 0.5;
		}

		public override double Health
		{
			get
			{
				return health;
			}
		 set
			{
				if (value < 0)
				{
					this.IsAlive = false;
				}
				if (value > 50)
				{
					this.health = 50;
				}
				else
				{
					this.health = value;
				}
			}
		}

		public override string Type => "Cleric";

		public void Heal(Character character)
		{

		}
	}
}
