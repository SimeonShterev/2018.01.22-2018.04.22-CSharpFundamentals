using System;
using System.Collections.Generic;

public class CommonItemFactory : ICommonItemFactory
{
	public IItem GenetareCommonItem(IList<string> args)
	{
		Type type = Type.GetType("CommonItem");

		string itemName = args[0];
		string heroName = args[1];
		int strengthBonus = int.Parse(args[2]);
		int agilityBonus = int.Parse(args[3]);
		int intelligenceBonus = int.Parse(args[4]);
		int hitPointsBonus = int.Parse(args[5]);
		int damageBonus = int.Parse(args[6]);

		IItem commonItem = (IItem)Activator.CreateInstance(type, itemName, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
		return commonItem;
	}
}
	