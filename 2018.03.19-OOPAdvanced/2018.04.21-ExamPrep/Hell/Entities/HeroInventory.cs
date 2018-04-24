using System.Collections.Generic;
using System.Linq;

public class HeroInventory : IInventory
{
    private Dictionary<string, IItem> commonItems;
    private Dictionary<string, IRecipe> recipeItems;
	private ICommonItemFactory commonItemFactory;

    public HeroInventory()
    {
        this.commonItems = new Dictionary<string, IItem>();
        this.recipeItems = new Dictionary<string, IRecipe>();
		this.commonItemFactory = new CommonItemFactory();
    }

    public int TotalStrengthBonus
    {
        get { return this.commonItems.Values.Sum(i => i.StrengthBonus); }
    }

    public int TotalAgilityBonus
    {
        get { return this.commonItems.Values.Sum(i => i.AgilityBonus); }
    }

    public int TotalIntelligenceBonus
    {
        get { return this.commonItems.Values.Sum(i => i.IntelligenceBonus); }
    }

    public int TotalHitPointsBonus
    {
        get { return this.commonItems.Values.Sum(i => i.HitPointsBonus); }
    }

    public int TotalDamageBonus
    {
        get { return this.commonItems.Values.Sum(i => i.DamageBonus); }
    }

	public IReadOnlyDictionary<string, IItem> AllItems => this.commonItems;

	public void AddCommonItem(IItem item)
    {
        this.commonItems.Add(item.Name, item);
        this.CheckRecipes();
    }

    public void AddRecipeItem(IRecipe recipe)
    {
        this.recipeItems.Add(recipe.Name, recipe);
        this.CheckRecipes();
    }

    private void CheckRecipes()
    {
        foreach (IRecipe recipe in this.recipeItems.Values)
        {
            List<string> requiredItems = new List<string>(recipe.RequiredItems);

            foreach (IItem commonItem in this.commonItems.Values)
            {
                if (requiredItems.Contains(commonItem.Name))
                {
                    requiredItems.Remove(commonItem.Name);
                }
            }

            if (requiredItems.Count == 0)
            {
                this.CombineRecipe(recipe);
            }
        }
    }

    private void CombineRecipe(IRecipe recipe)
    {
        for (int i = 0; i < recipe.RequiredItems.Count; i++)
        {
            string item = recipe.RequiredItems[i];
            this.commonItems.Remove(item);
        }

		IList<string> args = new List<string>() { recipe.Name, recipe.HeroName, recipe.StrengthBonus.ToString(), recipe.AgilityBonus.ToString(), recipe.IntelligenceBonus.ToString(), recipe.HitPointsBonus.ToString(), recipe.DamageBonus.ToString() };

		IItem newItem = this.commonItemFactory.GenetareCommonItem(args);

        this.commonItems.Add(newItem.Name, newItem);
    }
}