using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ranker : Soldier
{
	private const double overallSkillMultiplier = 1.5;

	private readonly List<string> weaponsAllowed = new List<string>()
	{
		"Gun"
		,"AutomaticMachine"
		,"Helmet"
	};

	public Ranker(string name, int age, double experiece, double endurance)
		: base(name, age, experiece, endurance) { }

	public override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

	public override double OverallSkillMultiplier => overallSkillMultiplier;
}