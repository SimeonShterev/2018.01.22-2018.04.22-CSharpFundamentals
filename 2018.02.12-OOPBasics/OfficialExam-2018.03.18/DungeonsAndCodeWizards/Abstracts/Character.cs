using DungeonsAndCodeWizards.Classes.Bags;
using DungeonsAndCodeWizards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Abstracts
{
	public abstract class Character
	{
		private double health;

		protected Character(string name, double baseHealth, double baseArmor, double abilityPoints, Bag bag, Faction faction)
		{
			this.Name = name;
			this.BaseHealth = baseHealth;
			this.Health = baseHealth;
			this.BaseArmor = baseArmor;
			this.Armor = baseArmor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
			this.Faction = faction;
		}
			

		public string Name { get; private set; }

		public abstract string Type { get; }

		public abstract double Health { get; set; }

		public double BaseHealth { get; }

		public double Armor { get; set; }

		public double BaseArmor { get; }

		public double AbilityPoints { get; set; }

		public Bag Bag { get; set; }

		public bool IsAlive { get; set; }

		public double RestHealMultiplier { get; protected set; }

		public Faction Faction { get; }

		public void TakeDamage(double hitPoints)
		{

		}

		public void Rest()
		{

		}

		public void UseItem(Item item)
		{
			Item myItem = this.Bag.GetItem(item.Name);
		}

		public void UseItemOn(Item item, Character character)
		{
			Item myItem = this.Bag.GetItem(item.Name);
			switch (item.Name)
			{
				case "HealthPotion":
					item.AffectCharacter(character);
					break;
				case "ArmorRepairKit":
					item.AffectCharacter(character);
					break;
				case "PoisonPotion":
					item.AffectCharacter(character);
					break;
				default:
					// throw ex
					break;
			}
		}

		public void GiveCharacterItem(Item item, Character character)
		{
			character.Bag.AddItem(item);
		}

		public void ReceiveItem(Item item)
		{
			this.Bag.AddItem(item);
		}
	}
}
