using System;
using System.Collections.Generic;
using System.Text;

public class RemoveCommand : Command
{
	public RemoveCommand(string[] data, WeaponFactory weaponFactory, WeaponsRepository weaponsRepository, GemFactory gemFactory)
	: base(data, weaponFactory, weaponsRepository, gemFactory)
	{
	}

	public override void Execute()
	{
		string weaponName = this.data[0];
		int socketIndex = int.Parse(data[1]);
		this.weaponsRepository.RemoveGem(weaponName, socketIndex);
	}
}
