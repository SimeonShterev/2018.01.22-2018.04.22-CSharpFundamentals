using System;
using System.Collections.Generic;
using System.Text;


[Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", new string[] { "Pesho", "Svetlio"})]
public abstract class Weapon : IWeapon
{
	private int minDamage;
	private int maxDamage;
	private int sockets;
	private Gem[] gems;

	public Weapon(WeaponRarity weaponRarity, int minDamage, int maxDamage, int sockets)
	{
		this.MinDamage = minDamage * (int)weaponRarity;
		this.MaxDamage = maxDamage * (int)weaponRarity;
		this.sockets = sockets;
		this.gems = new Gem[sockets];
	}

	public int Sockets
	{
		get { return this.sockets; }
	}

	public int MaxDamage
	{
		get { return this.maxDamage; }
		private set { this.maxDamage = value; }
	}

	public int MinDamage
	{
		get { return this.minDamage; }
		private set { this.minDamage = value; }
	}

	public void AddGem(int socketIndex, Gem gem)
	{
		if(socketIndex<0 || socketIndex>this.gems.Length)
		{
			throw new IndexOutOfRangeException("Invalid Index");
		}
		this.gems[socketIndex] = gem;
	}

	public void RemoveGem(int socketIndex)
	{
		if (socketIndex < 0 || socketIndex > this.gems.Length)
		{
			throw new IndexOutOfRangeException("Invalid Index");
		}
		if(this.gems[socketIndex] == null)
		{
			throw new InvalidOperationException("Empty Index");
		}
		this.gems[socketIndex] = null;
	}

	public override string ToString()
	{
		int strenght = 0;
		int agility = 0;
		int vitality = 0;
		foreach (var gem in this.gems)
		{
			if (gem!=null)
			{
				strenght += gem.Strenght;
				agility += gem.Agility;
				vitality += gem.Vitality; 
			}
		}
		this.MinDamage += 2 * strenght + 1 * agility;
		this.MaxDamage += 3 * strenght + 4 * agility;

		return $": {this.MinDamage}-{this.MaxDamage} Damage, +{strenght} Strength, +{agility} Agility, +{vitality} Vitality";
	}
}