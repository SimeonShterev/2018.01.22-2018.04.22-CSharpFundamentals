using DungeonsAndCodeWizards.Classes.Bags;
using DungeonsAndCodeWizards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Abstracts
{
	public abstract class Character : ICharacter
	{
		private double health;

		protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
		{
			this.Name = name;
			this.BaseHealth = health;
			this.Health = health;
			this.BaseArmor = armor;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
			this.Faction = faction;
			this.IsAlive = true;
		}

		public string Name { get; }

		public double Health
		{
			get
			{
				return this.health;
			}
			set
			{
				if (value <= 0)
				{
					this.IsAlive = false;
					this.health = value;
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

		public double BaseHealth { get; private set; }

		public double Armor { get; set; }

		public double BaseArmor { get; private set; }

		public double AbilityPoints { get; private set; }

		public Bag Bag { get; set; }

		public bool IsAlive { get; set; }

		public double RestHealMultiplier { get; protected set; }

		public Faction Faction { get; }

		private string Status
		{
			get
			{
				if (this.IsAlive)
				{
					return "Alive";
				}
				else
				{
					return "Dead";
				}
			}
		}

		public abstract string Type { get; }

		public void TakeDamage(double hitPoints)
		{
			CheckIsAlive(this);
			bool reduceArmor = this.Armor > 0;
			if (this.Armor > hitPoints)
			{
				this.Armor -= hitPoints;
			}
			else
			{
				hitPoints -= this.Armor;
				this.Armor = 0;
				if (this.Health > hitPoints)
				{
					this.Health -= hitPoints;
				}
				else
				{
					this.Health = 0;
				}
			}
		}

		public void Rest()
		{
			this.Health += this.BaseHealth * this.RestHealMultiplier;
		}

		public void UseItem(Item item)
		{
			CheckIsAlive(this);
			item.AffectCharacter(this);
			RemoveItemFromBag(item);
		}

		public void UseItemOn(Item item, Character character)
		{
			CheckIsAlive(this);
			CheckIsAlive(character);
			item.AffectCharacter(character);
			RemoveItemFromBag(item);
		}

		public void GiveCharacterItem(Item item, Character character)
		{
			CheckIsAlive(this);
			CheckIsAlive(character);
			character.ReceiveItem(item);
			RemoveItemFromBag(item);
		}

		public void ReceiveItem(Item item)
		{
			CheckIsAlive(this);
			this.Bag.AddItem(item);
		}


		protected static void CheckIsAlive(Character character)
		{
			if (!character.IsAlive)
			{
				throw new InvalidOperationException(ErrorMessages.Dead);
			}
		}

		private void RemoveItemFromBag(Item item)
		{
			this.Bag.itemsInTheBag.Remove(item);
			this.Bag.currentWeightOfBag -= item.Weight;
		}

		public override string ToString()
		{
			return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {this.Status}";
		}
	}
}
