using System;
using System.Collections.Generic;
using System.Linq;

public class RecipeFactory : IRecipeFactory
{
	public IRecipe GenerateRecipe(IList<string> args)
	{
		Type type = Type.GetType("Recipe");

		string itemName = args[0];
		string heroName = args[1];
		int strengthBonus = int.Parse(args[2]);
		int agilityBonus = int.Parse(args[3]);
		int intelligenceBonus = int.Parse(args[4]);
		int hitPointsBonus = int.Parse(args[5]);
		int damageBonus = int.Parse(args[6]);
		string[] requiredItems = args.Skip(7).ToArray();

		IRecipe recipe = (IRecipe)Activator.CreateInstance(type, itemName, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);
		return recipe;
	}
}