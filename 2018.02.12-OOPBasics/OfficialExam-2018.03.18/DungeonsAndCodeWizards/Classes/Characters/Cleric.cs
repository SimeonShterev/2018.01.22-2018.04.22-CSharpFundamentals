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
		public Cleric(string name, Faction faction)
			: base(name, 50d, 25d, 40d, new Backpack(), faction)
		{
			this.RestHealMultiplier = 0.5;
		}

		public override string Type => "Cleric";

		public void Heal(Character character)
		{
			CheckIsAlive(this);
			CheckIsAlive(character);
			bool differentFaction = this.Faction != character.Faction;
			if(differentFaction)
			{
				throw new InvalidOperationException(ErrorMessages.HealingEnemy);
			}
			character.Health += this.AbilityPoints;
		}
	}
}
