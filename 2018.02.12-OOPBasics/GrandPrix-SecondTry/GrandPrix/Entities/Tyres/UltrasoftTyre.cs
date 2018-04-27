using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
	private double degradation;

	public UltrasoftTyre(double hardness, double grip) 
		: base("Ultrasoft", hardness)
	{
		this.Grip = grip;
	}

	public double Grip { get; }

	public override double Degradation
	{
		get
		{
			return this.degradation;
		}
		protected set
		{
			if (value < 30)
			{
				throw new InvalidOperationException(Consts.BlownTyre);
			}
			this.degradation = value;
		}
	}
	public override void CompleteLap()
	{
		this.Degradation -= (this.Hardness + this.Grip);
	}
}