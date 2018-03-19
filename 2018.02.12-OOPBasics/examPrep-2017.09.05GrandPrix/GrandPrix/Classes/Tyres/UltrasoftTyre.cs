using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
	private const double MinimumDegragation = 30d;

	private double degradation;

	public UltrasoftTyre(string name, double hardness, double grip)
		: base("Ultrasoft")
	{
		this.Hardness = hardness + grip;
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