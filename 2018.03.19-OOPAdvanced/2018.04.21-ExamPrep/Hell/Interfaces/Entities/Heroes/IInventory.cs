using System.Collections.Generic;

public interface IInventory
{
	int TotalStrengthBonus { get; }

	int TotalAgilityBonus { get; }

	int TotalIntelligenceBonus { get; }

	int TotalHitPointsBonus { get; }

	int TotalDamageBonus { get; }

	void AddCommonItem(IItem item);

	void AddRecipeItem(IRecipe recipe);

	IReadOnlyDictionary<string, IItem> AllItems { get; }
}