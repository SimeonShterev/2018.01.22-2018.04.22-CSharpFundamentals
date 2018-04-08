using System;
using System.Collections.Generic;
using System.Text;

public class WeaponFactory
{
	public Weapon CreateWeapon(string[] weaponData)
	{
		string weaponRarity = weaponData[0];
		WeaponRarity rarity = Enum.Parse<WeaponRarity>(weaponRarity);
		string weaponType = weaponData[1];
		Type type = Type.GetType(weaponType);
		Weapon weapon = (Weapon)Activator.CreateInstance(type, new object[] { rarity });
		return weapon;
	}
}