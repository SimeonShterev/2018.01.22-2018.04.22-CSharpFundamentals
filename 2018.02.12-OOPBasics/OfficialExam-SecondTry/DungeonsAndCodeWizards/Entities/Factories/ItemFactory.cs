using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Factories
{
    public class ItemFactory
    {
		public Item CreateItem(string itemType)
		{
			// no reflection allowed
			if(itemType!= "HealthPotion" && itemType!= "PoisonPotion" && itemType!= "ArmorRepairKit")
			{
				throw new ArgumentException(string.Format(Consts.InvalidItem, itemType));
			}

			Assembly assembly = Assembly.GetCallingAssembly();
			Type type = assembly.GetTypes().First(t => t.Name == itemType);

			Item item = (Item)Activator.CreateInstance(type);
			return item;
		}
    }
}
