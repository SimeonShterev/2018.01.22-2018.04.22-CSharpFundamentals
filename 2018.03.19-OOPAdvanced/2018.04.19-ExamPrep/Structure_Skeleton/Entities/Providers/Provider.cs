using System;

public abstract class Provider : IProvider
{
	private const double InitialDurability = 1000d;
	private const double DurabilityLoss = 100d;

	protected Provider(int id, double energyOutput)
	{
		this.ID = id;
		this.EnergyOutput = energyOutput;
		this.Durability = InitialDurability;
	}

	public virtual double EnergyOutput { get; protected set; }

	public int ID { get; }

	public virtual double Durability { get; protected set; }

	public void Broke()
	{
		this.Durability -= DurabilityLoss;
		if (this.Durability < 0)
		{
			throw new InvalidOperationException();
		}
	}

	public double Produce()
	{
		return this.EnergyOutput;
	}

	public void Repair(double val)
	{
		this.Durability += val;
	}

	public override string ToString()
	{
		return this.GetType().Name + Environment.NewLine + string.Format(Constants.ToStringInfo, this.Durability);
	}
}