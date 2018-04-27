using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
	public class Cleric : Character, IHealable
	{
		private const double baseArmor = 25d;
		private const double baseHealth = 50d;
		private const double abilityPoints = 40d;

		private const double restHealMultiplier = 0.5;

		public Cleric(string name, Faction faction)
			: base(name, faction)
		{
			this.BaseHealth = baseHealth;
			this.BaseArmor = baseArmor;
			this.Health = baseHealth;
			this.Armor = baseArmor;
			this.AbilityPoints = abilityPoints;
			this.Bag = new Backpack();
		}

		public override double BaseHealth { get; protected set; }

		public override double BaseArmor { get; protected set; }

		public override double RestHealMultiplier => restHealMultiplier;


		public void Heal(Character character)
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(Consts.DeadCharacter);
			}
			if (!character.IsAlive)
			{
				throw new InvalidOperationException(Consts.DeadCharacter);
			}

			if(this.Faction!=character.Faction)
			{
				throw new InvalidOperationException(Consts.HealEnemy);
			}

			character.Health += this.AbilityPoints;
		}
	}
}
