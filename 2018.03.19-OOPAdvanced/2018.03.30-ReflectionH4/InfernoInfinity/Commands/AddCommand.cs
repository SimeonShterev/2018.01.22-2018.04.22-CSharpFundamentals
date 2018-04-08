using System;
using System.Collections.Generic;
using System.Text;

public class AddCommand : Command
{
	public AddCommand(string[] data, WeaponFactory weaponFactory, WeaponsRepository weaponsRepository, GemFactory gemFactory)
		: base(data, weaponFactory, weaponsRepository, gemFactory)
	{
	}

	public override void Execute()
	{
		string[] gemData = this.data[2].Split();
		Gem gem = this.gemFactory.CreateGem(gemData);
		string weaponName = this.data[0];
		int socketIndex = int.Parse(data[1]);
		this.weaponsRepository.AddGem(weaponName, socketIndex, gem);
	}
}