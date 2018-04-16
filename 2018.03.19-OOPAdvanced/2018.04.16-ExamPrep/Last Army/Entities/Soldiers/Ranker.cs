using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ranker : Soldier
{
	private const double OverallSkillMultiplier = 1.5;

	private readonly List<string> ammunitions = new List<string>()
	{
		"Gun"
		,"AutomaticMachine"
		,"Helmet"
	};

	public Ranker(string name, int age, double experiece, double endurance) 
		: base(name, age, experiece, endurance)
	{
		this.OverallSkill = (age + experiece) * OverallSkillMultiplier;
	}

	protected override IReadOnlyList<string> WeaponsAllowed => this.ammunitions;
}