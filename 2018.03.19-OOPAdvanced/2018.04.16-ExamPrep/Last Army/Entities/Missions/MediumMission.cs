using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MediumMission : Mission
{
	private const int Endurance_Required = 50;
	private const int Wear_Level_Decrement = 50;

	public MediumMission(double scoreToComplete)
		: base(scoreToComplete) { }

	public override double EnduranceRequired => Endurance_Required;

	public override double WearLevelDecrement => Wear_Level_Decrement;
}