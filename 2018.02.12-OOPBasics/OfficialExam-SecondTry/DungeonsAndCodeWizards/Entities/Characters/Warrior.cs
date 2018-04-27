using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;

namespace DungeonsAndCodeWizards.Entities.Characters
{
	public class Warrior : Character, IAttackable
	{
		private const double baseArmor = 50d;
		private const double baseHealth = 100d;
		private const double abilityPoints = 40d;

		public Warrior(string name, Faction faction)
			: base(name, faction)
		{
			this.BaseHealth = baseHealth;
			this.BaseArmor = baseArmor;
			this.Health = baseHealth;
			this.Armor = baseArmor;
			this.AbilityPoints = abilityPoints;
			this.Bag = new Satchel();
		}

		public override double BaseHealth { get; protected set; }

		public override double BaseArmor { get; protected set; }

		public void Attack(Character character)
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(Consts.DeadCharacter);
			}
			if (!character.IsAlive)
			{
				throw new InvalidOperationException(Consts.DeadCharacter);
			}

			if(this.Equals(character))
			{
				throw new InvalidOperationException(Consts.SelfAttack);
			}
			if(this.Faction == character.Faction)
			{
				throw new ArgumentException(string.Format(Consts.FriendlyFire, this.Faction));
			}

			character.TakeDamage(this.AbilityPoints);
		}
	}
}
