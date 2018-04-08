using System;
using System.Collections.Generic;
using System.Text;

public class CreateCommand : Command
{
	public CreateCommand(string[] data, WeaponFactory weaponFactory, WeaponsRepository weaponsRepository, GemFactory gemFactory)
			: base(data, weaponFactory, weaponsRepository, gemFactory)
	{
	}

	public override void Execute()
	{
		string[] weaponStrenghtData = this.data[0].Split();
		Weapon weapon = this.weaponFactory.CreateWeapon(weaponStrenghtData);
		this.weaponsRepository.CreateWeapon(this.data[1], weapon);
	}
}