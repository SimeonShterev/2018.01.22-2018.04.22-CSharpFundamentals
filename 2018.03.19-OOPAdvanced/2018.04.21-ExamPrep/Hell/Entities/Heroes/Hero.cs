using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class Hero : IHero
{
	private int strength;
	private int agility;
	private int intelligence;
	private int hitPoints;
	private int damage;

	protected Hero(string name)
	{
		this.Name = name;
		this.Inventory = new HeroInventory();
	}

	public string Name { get; }

	public int Strength
	{
		get { return this.strength + this.Inventory.TotalStrengthBonus; }
		protected set { this.strength = value; }
	}

	public int Agility
	{
		get { return this.agility + this.Inventory.TotalAgilityBonus; }
		protected set { this.agility = value; }
	}

	public int Intelligence
	{
		get { return this.intelligence + this.Inventory.TotalIntelligenceBonus; }
		protected set { this.intelligence = value; }
	}

	public int HitPoints
	{
		get { return this.hitPoints + this.Inventory.TotalHitPointsBonus; }
		protected set { this.hitPoints = value; }
	}

	public int Damage
	{
		get { return this.damage + this.Inventory.TotalDamageBonus; }
		protected set { this.damage = value; }
	}

	public IInventory Inventory { get; private set; }

	public void AddRecipe(Recipe recipe)
	{
		this.Inventory.AddRecipeItem(recipe);
	}

	public override string ToString()
	{
		StringBuilder builder = new StringBuilder();

		builder.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}");
		builder.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
		builder.AppendLine($"Strength: {this.Strength}");
		builder.AppendLine($"Agility: {this.Agility}");
		builder.AppendLine($"Intelligence: {this.Intelligence}");
		builder.Append($"Items: ");///

		int length = this.Inventory.AllItems.Count;
		if (length == 0)
		{
			builder.Append("None");
			return builder.ToString().Trim();
		}
		builder.AppendLine();

		foreach (var item in this.Inventory.AllItems.Values)
		{
			builder.AppendLine(item.ToString());
		}

		return builder.ToString().Trim();
	}

	public string FinalOutput()
	{
		StringBuilder builder = new StringBuilder();
		builder.AppendLine(this.GetType().Name + ": " + this.Name);
		builder.AppendLine($"###HitPoints: {this.HitPoints}");
		builder.AppendLine($"###Damage: {this.Damage}");
		builder.AppendLine($"###Strength: {this.Strength}");
		builder.AppendLine($"###Agility: {this.Agility}");
		builder.AppendLine($"###Intelligence: {this.Intelligence}");

		int lenght = this.Inventory.AllItems.Count;
		if (lenght == 0)
		{
			builder.AppendLine("###Items: None");
			return builder.ToString().Trim();
		}

		builder.AppendLine("###Items: " + string.Join(", ", this.Inventory.AllItems.Keys));

		return builder.ToString().Trim();
	}
}