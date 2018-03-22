using DungeonsAndCodeWizards.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Contracts
{
	public interface ICharacter
	{
		string Name { get; }

		double Health { get; }

		double BaseHealth { get; }

		double Armor { get; }

		double BaseArmor { get; }

		double AbilityPoints { get; }

		Bag Bag { get; }

		Faction Faction { get; }

		bool IsAlive { get; }

		double RestHealMultiplier { get; }

		void TakeDamage(double hitPoints);

		void Rest();

		void UseItem(Item item);

		void UseItemOn(Item item, Character character);

		void GiveCharacterItem(Item item, Character character);

		void ReceiveItem(Item item);
	}
}
