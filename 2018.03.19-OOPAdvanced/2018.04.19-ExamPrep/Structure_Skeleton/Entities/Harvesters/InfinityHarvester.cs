using System;

public class InfinityHarvester : Harvester
{
    private const double OreOutputDivider = 10d;
	private const double PermenantDurability = 1000d;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) 
		: base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

    public override double Durability
    {
        get => this.durability;
		protected set => this.durability = PermenantDurability;
    }
}