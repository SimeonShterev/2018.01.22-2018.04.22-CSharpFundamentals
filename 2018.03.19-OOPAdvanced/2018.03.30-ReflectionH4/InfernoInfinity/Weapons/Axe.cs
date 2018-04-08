using System;
using System.Collections.Generic;
using System.Text;

public class Axe : Weapon
{
	private const int DefaultMinDamage = 5;
	private const int DefaultMaxDamage = 10;
	private const int DefaultSockets = 4;

	public Axe(WeaponRarity weaponRarity) 
		: base(weaponRarity, DefaultMinDamage, DefaultMaxDamage, DefaultSockets)
	{
	}
}