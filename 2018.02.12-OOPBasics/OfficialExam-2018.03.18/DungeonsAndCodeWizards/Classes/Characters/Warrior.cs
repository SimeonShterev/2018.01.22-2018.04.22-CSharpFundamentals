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
		public Warrior(string name, Faction faction) 
			: base(name, 100d, 50d, 40d, new Satchel(), faction)
		{
			this.RestHealMultiplier = 0.2;
		}

		public override string Type => "Warrior";

		public void Attack(Character character) 
		{
			CheckIsAlive(this);
			CheckIsAlive(character);
			bool checkSelf = this.Name == character.Name;
			if(checkSelf)
			{
				throw new InvalidOperationException(ErrorMessages.AttackSelf);
			}
			bool sameFaction = this.Faction == character.Faction;
			if(sameFaction)
			{
				throw new ArgumentException(string.Format(ErrorMessages.FriendlyFire, this.Faction));
			}
			character.TakeDamage(this.AbilityPoints);
		}
	}
}
