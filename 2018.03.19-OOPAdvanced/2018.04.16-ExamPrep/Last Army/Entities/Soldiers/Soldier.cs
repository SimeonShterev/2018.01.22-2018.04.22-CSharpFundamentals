using System.Collections.Generic;
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
		this.Weapons = new Dictionary<string, IAmmunition>();
		this.InitialiseWeapon();
		this.OverallSkill = (this.Age + this.Experience) * this.OverallSkillMultiplier;
	}

	public IDictionary<string, IAmmunition> Weapons { get; }

	public abstract IReadOnlyList<string> WeaponsAllowed { get; }

	public string Name { get; }

	public int Age { get; }

	public double Experience { get; private set; }

	public double Endurance { get; private set; }

	public double OverallSkill { get; private set; }

	public abstract double OverallSkillMultiplier { get; }

	public virtual int EnduranceIncreacement => Endurance_Increacement;

	private void InitialiseWeapon()
	{
		foreach (var weapon in this.WeaponsAllowed)
		{
			this.Weapons.Add(weapon, null);
		}
	}

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
		this.Endurance -= mission.EnduranceRequired;
		this.Experience += mission.EnduranceRequired;
		this.AmmunitionRevision(mission.WearLevelDecrement);
		this.OverallSkill = (this.Age + this.Experience) * this.OverallSkillMultiplier;
	}

	public override string ToString()
	{
		return string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
	}
}