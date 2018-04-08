using System;
using System.Collections.Generic;
using System.Text;

public class WeaponsRepository
{
	private Dictionary<string, Weapon> weapons;

	public WeaponsRepository()
	{
		this.weapons = new Dictionary<string, Weapon>();
	}

	public void CreateWeapon(string weaponName, Weapon weapon)
	{
		this.weapons.Add(weaponName, weapon);
	}

	public void AddGem(string weaponName, int socketIndex, Gem gem)
	{
		this.weapons[weaponName].AddGem(socketIndex, gem);
	}

	public void RemoveGem(string weaponName, int socketIndex)
	{
		this.weapons[weaponName].RemoveGem(socketIndex);
	}

	public string Print(string weaponName)
	{
		return weaponName + this.weapons[weaponName];
	}
}