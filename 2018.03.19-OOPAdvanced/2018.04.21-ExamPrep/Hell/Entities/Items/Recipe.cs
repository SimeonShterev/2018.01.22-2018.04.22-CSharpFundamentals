using System.Collections.Generic;

public class Recipe : IRecipe
{
	public Recipe(string name, string heroName, int strengthBonus, int agilityBonus, int inteligenceBonus, int hitPointsBomus, int damageBonus, params string[] requiredItems)
	{
		this.Name = name;
		this.HeroName = heroName;
		this.StrengthBonus = strengthBonus;
		this.AgilityBonus = agilityBonus;
		this.IntelligenceBonus = inteligenceBonus;
		this.HitPointsBonus = hitPointsBomus;
		this.DamageBonus = damageBonus;
		this.RequiredItems = requiredItems;
	}

	public string Name { get; }

	public int StrengthBonus { get; }

	public int AgilityBonus { get; }

	public int IntelligenceBonus { get; }

	public int HitPointsBonus { get; }

	public int DamageBonus { get; }

	public string HeroName { get; }

	public IReadOnlyList<string> RequiredItems { get; }
}