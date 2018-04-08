using System;
using System.Collections.Generic;
using System.Text;

public class PrintCommand : Command
{
	public PrintCommand(string[] data, WeaponFactory weaponFactory, WeaponsRepository weaponsRepository, GemFactory gemFactory) : base(data, weaponFactory, weaponsRepository, gemFactory)
	{
	}

	public override void Execute()
	{
		string weaponName = this.data[0];
		string output = this.weaponsRepository.Print(weaponName);
		Console.WriteLine(output);
	}
}