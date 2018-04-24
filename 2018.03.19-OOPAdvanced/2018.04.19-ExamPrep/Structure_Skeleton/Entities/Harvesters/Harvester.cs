using System;

public abstract class Harvester : IHarvester
{
    private const double InitialDurability = 1000.0;
	private const double DurabilityLoss = 100.0;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability { get; protected set; }

	public void Broke()
	{
		this.Durability -= DurabilityLoss;
		if(this.Durability<0)
		{
			throw new InvalidOperationException();
		}
	}

	public double Produce()
	{
		return this.OreOutput;
	}

	public override string ToString()
	{
		return this.GetType().Name + Environment.NewLine + string.Format(Constants.ToStringInfo, this.Durability);
	}
}