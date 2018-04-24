using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Ammunition : IAmmunition
{
	private const int wearLevelMultiplier = 100;

	public Ammunition()
	{
		this.WearLevel = this.Weight * 100;
	}

	public string Name => this.GetType().Name;

	public abstract double Weight { get; }

	public double WearLevel { get; private set; }

	public void DecreaseWearLevel(double wearAmount)
	{
		this.WearLevel -= wearAmount;
	}
}