using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Mission : IMission
{
	public Mission(double scoreToComplete)
	{
		this.ScoreToComplete = scoreToComplete;
	}

	public string Name => this.GetType().Name;

	public abstract double EnduranceRequired { get; }

	public double ScoreToComplete { get; }

	public abstract double WearLevelDecrement { get; }
}
