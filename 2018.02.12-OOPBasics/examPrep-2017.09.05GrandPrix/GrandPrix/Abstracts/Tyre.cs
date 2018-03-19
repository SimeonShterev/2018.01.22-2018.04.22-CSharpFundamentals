using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyre
{
	private const double InitialDegregation = 100d;

	public Tyre(string name)
	{
		this.Name = name;
		this.Degradation = InitialDegregation;
	}

	public string Name { get; }

	public abstract double Hardness { get; protected set; }

	public abstract double Degradation { get; protected set; }

	public virtual void ChangeTyres(double tyreHardness, double grip=0)
	{
		this.Degradation = InitialDegregation;
		this.Hardness = tyreHardness + grip;
	}

	public void ReduceDegradation()
	{
		this.Degradation -= this.Hardness;
	}
}