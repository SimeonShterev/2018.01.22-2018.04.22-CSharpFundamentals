using System;
using System.Collections.Generic;
using System.Text;

public abstract class Command : IExecutable
{
	protected string[] data;
	protected WeaponFactory weaponFactory;
	protected WeaponsRepository weaponsRepository;
	protected GemFactory gemFactory;

	public Command(string[] data, WeaponFactory weaponFactory, WeaponsRepository weaponsRepository, GemFactory gemFactory)
	{
		this.data = data;
		this.weaponFactory = weaponFactory;
		this.weaponsRepository = weaponsRepository;
		this.gemFactory = gemFactory;
	}

	public abstract void Execute();
}