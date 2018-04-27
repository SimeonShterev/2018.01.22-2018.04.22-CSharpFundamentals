﻿using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyre
{
	private double degradation;

	protected Tyre(string name, double hardness)
	{
		this.Name = name;
		this.Hardness = hardness;
		this.Degradation = 100;
	}

	public string Name { get; }

	public double Hardness { get; }

	public virtual double Degradation
	{
		get
		{
			return this.degradation;
		}
		protected set
		{
			if(value< 0)
			{
				throw new InvalidOperationException(Consts.BlownTyre);
			}
			this.degradation = value;
		}
	}

	public virtual void CompleteLap()
	{
		this.Degradation -= this.Hardness;
	}
}