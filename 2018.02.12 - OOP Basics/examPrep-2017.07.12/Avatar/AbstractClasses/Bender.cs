using System;
using System.Collections.Generic;
using System.Text;

public abstract class Bender : IBender
{
	private string name;
	private int power;

	public Bender(string name, int power)
	{
		this.Name = name;
		this.Power = power;
	}

	public int Power
	{
		get { return this.power; }
		set { this.power = value; }
	}

	public string Name
	{
		get { return this.name; }
		set { this.name = value; }
	}

	public override string ToString()
	{
		string result = $" Bender: {this.name}, Power: {this.power}, ";
		return result;
	}
}