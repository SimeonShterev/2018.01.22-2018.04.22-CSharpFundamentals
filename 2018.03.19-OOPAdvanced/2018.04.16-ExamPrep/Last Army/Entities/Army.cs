using System;
using System.Collections.Generic;
using System.Linq;

public class Army : IArmy
{
	private List<ISoldier> soldiers;
	private IWareHouse wareHouse;

	public Army(IWareHouse wareHouse)
	{
		this.soldiers = new List<ISoldier>();
		this.wareHouse = wareHouse;
	}

	public IReadOnlyList<ISoldier> Soldiers => this.soldiers.OrderByDescending(s => s.OverallSkill).ToList();

	public void AddSoldier(ISoldier soldier)
	{
		if (!this.wareHouse.TryEquipSodier(soldier))
		{
			throw new ArgumentException(string.Format(OutputMessages.NoWeaponForSoldier, soldier.GetType().Name, soldier.Name));
		}
		this.soldiers.Add(soldier);
	}

	public void RegenerateTeam(string soldierType)
	{
		Type type = Type.GetType(soldierType);
		foreach (var soldier in this.soldiers.Where(s=>s.GetType() == type).ToList())
		{
			soldier.Regenerate();
		}
	}
}