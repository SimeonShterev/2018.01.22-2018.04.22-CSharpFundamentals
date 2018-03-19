using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : Unit, IProvider
{
	private const int MaxEnergyOutput = 10_000;

	private double energyOutput;

	protected Provider(string id, double energyOutput) 
		: base(id)
	{
		this.EnergyOutput = energyOutput;
	}

	public double EnergyOutput
	{
		get
		{
			return this.energyOutput;
		}
		private set
		{
			if (value <= 0 || value >= MaxEnergyOutput)
			{
				throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
			}
			this.energyOutput = value;
		}
	}

	public abstract override string ToString();

	public abstract string RegisterProviderToString();
}