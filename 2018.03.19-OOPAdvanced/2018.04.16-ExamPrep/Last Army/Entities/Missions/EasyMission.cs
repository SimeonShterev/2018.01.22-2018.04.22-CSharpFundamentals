using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EasyMission : Mission
{
	private const int Endurance_Required = 20;
	private const int Wear_Level_Decrement = 30;

	public EasyMission(double scoreToComplete)
		: base(scoreToComplete) { }

	public override double EnduranceRequired => Endurance_Required;

	public override double WearLevelDecrement => Wear_Level_Decrement;
}