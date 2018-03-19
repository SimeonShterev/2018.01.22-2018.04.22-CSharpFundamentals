using System;
using System.Collections.Generic;
using System.Text;

public class HardTyre : Tyre
{
	private const double MinimumDegragation = 0d;

	private double degradation;

	public HardTyre(string name, double hardness)
		: base("Hard")
	{
		this.Hardness = hardness;
	}

	public override double Degradation
	{
		get
		{
			return this.degradation;
		}
		protected set
		{
			if (value < MinimumDegragation)
			{
				throw new ArgumentException(FailMessages.BlownTyre);
			}
			this.degradation = value;
		}
	}

	public override double Hardness { get; protected set; }
}