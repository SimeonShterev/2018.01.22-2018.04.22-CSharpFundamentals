using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : Unit, IHarvester
{
	private const int MaxEnergyRequirement = 20_000;

	private double oreOutput;
	private double energyRequirement;

	protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
	{
		this.OreOutput = oreOutput;
		this.EnergyRequirement = energyRequirement;
	}

	public double OreOutput
	{
		get
		{
			return this.oreOutput;
		}
		private set
		{
			if(value<0)
			{
				throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
			}
			this.oreOutput = value;
		}
	}

	public double EnergyRequirement
	{
		get
		{
			return this.energyRequirement;
		}
		protected set
		{
			if (value < 0 || value > MaxEnergyRequirement )
			{
				throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
			}
			this.energyRequirement = value;
		}
	}

	public abstract override string ToString();

	public abstract string RegisterHarvesterToString();
}
