using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Classes.Bags;
using DungeonsAndCodeWizards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Classes.Characters
{
	public class Warrior : Character, IAttackable
	{
		private double health;

		public Warrior(string name, Faction faction) 
			: base(name, 100d, 50d, 40d, new Satchel(), faction)
		{
			this.RestHealMultiplier = 0.2;
		}

		public override double Health
		{
			get
			{
				return this.health;
			}
			set
			{
				if (value < 0)
				{
					this.IsAlive = false;
				}
				if (value > 100)
				{
					this.health = 100;
				}
				else
				{
					this.health = value;
				}
			}
		}

		public override string Type => "Warrior";

		public void Attack(Character character) 
		{
			throw new NotImplementedException();
		}
	}
}
