using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
	public abstract class Character
	{
		private const double DefaultRestHealMultiplier = 0.2;
		private double health;

		protected Character(string name, Faction faction)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException(Consts.NameNull);
			}
			this.Name = name;
			this.Faction = faction;
		}

		public string Name { get; }

		public abstract double BaseHealth { get; protected set; }

		public double Health
		{
			get
			{
				return this.health;
			}
			set
			{
				if (value < 0)
				{
					this.health = 0;
					this.IsAlive = false;
				}
				else if (value > this.BaseHealth)
				{
					this.health = this.BaseHealth;
				}
				else
				{
					this.health = value;
				}
			}
		}

		public abstract double BaseArmor { get; protected set; }

		public double Armor { get; set; }

		public double AbilityPoints { get; protected set; }

		public Bag Bag { get; protected set; } ///

		public Faction Faction { get; }

		public bool IsAlive { get; set; } = true;

		public virtual double RestHealMultiplier => DefaultRestHealMultiplier;

		public void TakeDamage(double hitPoints)
		{
			IsCharAlive();
			if (this.Armor >= hitPoints)
			{
				this.Armor -= hitPoints;
			}
			else
			{
				this.Health -= hitPoints - this.Armor;
				this.Armor = 0;
			}
		}

		public void Rest()
		{
			IsCharAlive();
			this.Health += this.BaseHealth * this.RestHealMultiplier;
		}

		public void UseItem(Item item)
		{
			IsCharAlive();
			item.AffectCharacter(this);
		}

		void UseItemOn(Item item, Character character)
		{
			character.IsCharAlive();
			item.AffectCharacter(character);
		}

		public void GiveCharacterItem(Item item, Character character)
		{
			IsCharAlive();
			character.IsCharAlive();

			this.ReceiveItem(item);
		}

		public void ReceiveItem(Item item)
		{
			IsCharAlive();
			this.Bag.AddItem(item);
		}

		private void IsCharAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(Consts.DeadCharacter);
			}
		}
	}
}
