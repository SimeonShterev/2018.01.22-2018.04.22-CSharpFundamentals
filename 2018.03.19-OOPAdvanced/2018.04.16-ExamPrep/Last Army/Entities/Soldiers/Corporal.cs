using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Corporal : Soldier
{
	private const double OverallSkillMultiplier = 2.5;

	private readonly List<string> ammunitions = new List<string>()
	{
		"Gun"
		,"AutomaticMachine"
		,"Helmet"
		,"MachineGun"
		,"Knife"
	};

	public Corporal(string name, int age, double experiece, double endurance) 
		: base(name, age, experiece, endurance)
	{
		this.OverallSkill = (age + experiece) * OverallSkillMultiplier;
	}

	protected override IReadOnlyList<string> WeaponsAllowed => this.ammunitions;
}