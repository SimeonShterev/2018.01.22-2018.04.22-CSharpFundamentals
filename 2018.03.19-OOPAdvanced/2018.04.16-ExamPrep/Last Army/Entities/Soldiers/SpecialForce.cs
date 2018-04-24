﻿using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
	private const double overallSkillMultiplier = 3.5;
	private const int Endurance_Increacement = 30;


	private readonly List<string> weaponsAllowed = new List<string>
		{
			"Gun",
			"AutomaticMachine",
			"MachineGun",
			"RPG",
			"Helmet",
			"Knife",
			"NightVision"
		};

	public SpecialForce(string name, int age, double experience, double endurance)
		: base(name, age, experience, endurance) { }

	public override IReadOnlyList<string> WeaponsAllowed => weaponsAllowed;

	public override int EnduranceIncreacement => Endurance_Increacement;

	public override double OverallSkillMultiplier => overallSkillMultiplier;
}