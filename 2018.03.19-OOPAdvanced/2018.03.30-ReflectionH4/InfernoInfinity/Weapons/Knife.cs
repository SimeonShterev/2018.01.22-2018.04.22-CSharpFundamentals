using System;
using System.Collections.Generic;
using System.Text;

public class Knife : Weapon
{
	private const int DefaultMinDamage = 3;
	private const int DefaultMaxDamage = 4;
	private const int DefaultSockets = 2;

	public Knife(WeaponRarity weaponRarity) 
		: base(weaponRarity, DefaultMinDamage, DefaultMaxDamage, DefaultSockets)
	{
	}
}