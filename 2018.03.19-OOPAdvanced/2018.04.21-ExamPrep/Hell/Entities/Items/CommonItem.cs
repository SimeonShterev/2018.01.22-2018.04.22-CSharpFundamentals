using System.Collections.Generic;
using System.Text;

public class CommonItem : IItem
{
	public CommonItem(string name, string heroName, int strengthBonus, int agilityBonus, int inteligenceBonus, int hitPointsBomus, int damageBonus) 
	{
		this.Name = name;
		this.HeroName = heroName;
		this.StrengthBonus = strengthBonus;
		this.AgilityBonus = agilityBonus;
		this.IntelligenceBonus = inteligenceBonus;
		this.HitPointsBonus = hitPointsBomus;
		this.DamageBonus = damageBonus;
	}

	public string Name { get; }

	public int StrengthBonus { get; }

	public int AgilityBonus { get; }

	public int IntelligenceBonus { get; }

	public int HitPointsBonus { get; }

	public int DamageBonus { get; }

	public string HeroName { get; }

	public override string ToString()
	{
		StringBuilder builder = new StringBuilder();

		builder.AppendLine($"###Item: {this.Name}");
		builder.AppendLine($"###+{this.StrengthBonus} Strength");
		builder.AppendLine($"###+{this.AgilityBonus} Agility");
		builder.AppendLine($"###+{this.IntelligenceBonus} Intelligence");
		builder.AppendLine($"###+{this.HitPointsBonus} HitPoints");
		builder.AppendLine($"###+{this.DamageBonus} Damage");

		return builder.ToString().Trim();
	}
}