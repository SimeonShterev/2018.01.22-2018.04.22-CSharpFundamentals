using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Engine
{
	private WeaponFactory weaponFactory;
	private WeaponsRepository weaponsRepository;
	private GemFactory gemFactory;

	public Engine()
	{
		this.weaponFactory = new WeaponFactory();
		this.weaponsRepository = new WeaponsRepository();
		this.gemFactory = new GemFactory();
	}

	public void Run()
	{
		string input;
		while ((input = Console.ReadLine()) != "END")
		{
			string commandName = input.Split(';')[0];
			string[] commandArgs = input.Split(';').Skip(1).ToArray();

			Type commandType = Type.GetType(commandName + "Command");
			object instance = Activator.CreateInstance(commandType, new object[] { commandArgs, this.weaponFactory, this.weaponsRepository, this.gemFactory });
			try
			{
				commandType.GetMethod("Execute").Invoke(instance, null);
			}
			catch (TargetInvocationException) { }
		}
	}
}