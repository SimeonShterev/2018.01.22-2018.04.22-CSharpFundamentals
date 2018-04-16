using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Ammunition : IAmmunition
{
	public string Name => this.GetType().Name;

	public abstract double Weight { get; }

	public abstract double WearLevel { get; }

	public void DecreaseWearLevel(double wearAmount)
	{
		throw new NotImplementedException();
	}
}