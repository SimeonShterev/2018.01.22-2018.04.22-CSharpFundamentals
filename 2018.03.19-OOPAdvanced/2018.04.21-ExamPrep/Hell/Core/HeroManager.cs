using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
	private IHeroFactory heroFactory;
	private ICommonItemFactory commonItemFactory;
	private IRecipeFactory recipeFactory;
    private Dictionary<string, IHero> heroes;

	public HeroManager()
	{
		this.heroFactory = new HeroFactory();
		this.commonItemFactory = new CommonItemFactory();
		this.recipeFactory = new RecipeFactory();
		this.heroes = new Dictionary<string, IHero>();
	}

    public string AddHero(IList<String> arguments)
    {
		IHero hero = this.heroFactory.GenerateHero(arguments);
		string heroName = hero.Name;
		this.heroes.Add(heroName, hero);
		return string.Format(Constants.HeroCreateMessage, hero.GetType().Name, hero.Name);
    }

    public string AddItemToHero(IList<String> arguments)
    {
		IItem item = this.commonItemFactory.GenetareCommonItem(arguments);
		string heroName = arguments[1];
		this.heroes[heroName].Inventory.AddCommonItem(item);
		return string.Format(Constants.ItemCreateMessage, item.Name, heroName);
    }

	public string AddRecipeToHero(IList<string> arguments)
	{
		IRecipe recipe = this.recipeFactory.GenerateRecipe(arguments);
		string heroName = arguments[1];
		this.heroes[heroName].Inventory.AddRecipeItem(recipe);
		return string.Format(Constants.RecipeCreatedMessage, recipe.Name, heroName);
	}

	public string Inspect(IList<string> arguments)
	{
		string heroName = arguments[0];

		return this.heroes[heroName].ToString();
	}

	public string Quit()
	{
		StringBuilder builder = new StringBuilder();
		int counter = 1;

		foreach (var hero in this.heroes.Values.OrderByDescending(h=>h.Strength + h.Agility + h.Intelligence)
												.ThenByDescending(h=>h.HitPoints + h.Damage))
		{
			builder.AppendLine($"{counter}. " + hero.FinalOutput());
			counter++;
		}

		return builder.ToString().Trim();
	}
}