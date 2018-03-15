using System;
using System.Collections.Generic;
using System.Text;

public abstract class Bender : Unit, IBender
{
	private int power;

	public Bender(string name, int power, double specialPowerMultiplicator) :
		base(name)
	{
		this.Power = power;
		this.SpecialPowerMultiplicator = specialPowerMultiplicator;
	}

	public int Power
	{
		get { return this.power; }
		private set { this.power = value; }
	}

	public double SpecialPowerMultiplicator { get; private set; }

	public override string ToString()
	{
		string result = $" Bender: {this.Name}, Power: {this.Power}, ";
		return result;
	}
}