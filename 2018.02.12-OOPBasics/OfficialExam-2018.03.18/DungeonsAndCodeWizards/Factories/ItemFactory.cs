using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Classes.Items;

namespace DungeonsAndCodeWizards.Factories
{
	public class ItemFactory
	{
		public Item CreateItem(string itemName)
		{
			switch (itemName)
			{
				case "HealthPotion":
					return new HealthPotion();
				case "PoisonPotion":
					return new PoisonPotion();
				case "ArmorRepairKit":
					return new ArmorRepairKit();
				default:
					throw new ArgumentException(string.Format(ErrorMessages.InvalidItemName, itemName));
			}
		}
	}
}
