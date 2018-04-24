using System;
using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
	private IDictionary<string, int> ammunitionsInWarehouse;
	private IAmmunitionFactory ammunitionFactory;
	private IWriter writer;

	public WareHouse(IWriter writer)
	{
		this.ammunitionsInWarehouse = new Dictionary<string, int>();
		this.ammunitionFactory = new AmmunitionFactory();
		this.writer = writer;
	}

	public void AddWeaponsToWarehouse(string weaponName, int weaponCount)
	{
		if (!this.ammunitionsInWarehouse.ContainsKey(weaponName))
		{
			this.ammunitionsInWarehouse.Add(weaponName, weaponCount);
		}
		else
		{
			this.ammunitionsInWarehouse[weaponName] += weaponCount;
		}
	}

	public void EquipArmy(IArmy army)
	{
		foreach (var soldier in army.Soldiers)
		{
			TryEquipSodier(soldier);
		}
	}

	public bool TryEquipSodier(ISoldier soldier)
	{
		Dictionary<string, int> ammunitionsInWarehouseCopy = new Dictionary<string, int>(this.ammunitionsInWarehouse);

		foreach (var weapon in this.ammunitionsInWarehouse.Keys)
		{
			if (soldier.Weapons.ContainsKey(weapon) && this.ammunitionsInWarehouse[weapon] > 0)
			{
				if (soldier.Weapons[weapon] == null || soldier.Weapons[weapon].WearLevel <= 0)
				{
					soldier.Weapons[weapon] = this.ammunitionFactory.CreateAmmunition(weapon);
					ammunitionsInWarehouseCopy[weapon]--;
				}
			}
		}

		if (soldier.Weapons.Any(w => w.Value == null))
		{
			return false;
		}
		else
		{
			this.ammunitionsInWarehouse = ammunitionsInWarehouseCopy;
			return true;
		}
	}
}