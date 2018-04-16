﻿using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
	private const int Endurance_Increacement = 10;

	public Soldier(string name, int age, double experience, double endurance)
	{
		this.Name = name;
		this.Age = age;
		this.Experience = experience;
		this.Endurance = endurance;
	}

	public IDictionary<string, IAmmunition> Weapons { get; }

	protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

	public string Name { get; }

	public int Age { get; }

	public double Experience { get; private set; }

	public double Endurance { get; private set; }

	public double OverallSkill { get; protected set; }

	public virtual int EnduranceIncreacement => Endurance_Increacement;

	//-----------------

	public bool ReadyForMission(IMission mission)
	{
		if (this.Endurance < mission.EnduranceRequired)
		{
			return false;
		}

		bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

		if (!hasAllEquipment)
		{
			return false;
		}

		return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
	}

	private void AmmunitionRevision(double missionWearLevelDecrement)
	{
		IEnumerable<string> keys = this.Weapons.Keys.ToList();
		foreach (string weaponName in keys)
		{
			this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

			if (this.Weapons[weaponName].WearLevel <= 0)
			{
				this.Weapons[weaponName] = null;
			}
		}
	}

	public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

	public void Regenerate()
	{
		this.Endurance += this.Age + this.EnduranceIncreacement;
		if (this.Endurance > 100)
		{
			this.Endurance = 100;
		}
	}

	public void CompleteMission(IMission mission)
	{
		throw new System.NotImplementedException();
	}
}