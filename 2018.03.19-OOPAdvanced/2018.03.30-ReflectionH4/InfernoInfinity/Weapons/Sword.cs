using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
	private const int DefaultMinDamage = 4;
	private const int DefaultMaxDamage = 6;
	private const int DefaultSockets = 3;

	public Sword(WeaponRarity weaponRarity) 
		: base(weaponRarity, DefaultMinDamage, DefaultMaxDamage, DefaultSockets)
	{
	}
}