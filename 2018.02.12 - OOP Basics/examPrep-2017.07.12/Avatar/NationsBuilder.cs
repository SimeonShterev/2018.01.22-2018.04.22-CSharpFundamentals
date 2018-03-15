using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder : INationsBuilder
{
	private BenderFactory benderFactory;
	private MonumentFactory monumentFactory;
	private Nation airNation;
	private Nation fireNation;
	private Nation waterNation;
	private Nation earthNation;
	private List<string> warsIssuedBy;

	public NationsBuilder()
	{
		benderFactory = new BenderFactory();
		monumentFactory = new MonumentFactory();
		airNation = new AirNation();
		earthNation = new EarthNation();
		fireNation = new FireNation();
		waterNation = new WaterNation();
		warsIssuedBy = new List<string>();
	}

	public void AssignBender(List<string> benderArgs)
	{
		Bender bender = this.benderFactory.CreateBender(benderArgs);
		string nation = benderArgs[0];
		switch (nation)
		{
			case "Air":
				airNation.AddBenders(bender);
				break;
			case "Fire":
				fireNation.AddBenders(bender);
				break;
			case "Water":
				waterNation.AddBenders(bender);
				break;
			case "Earth":
				earthNation.AddBenders(bender);
				break;
		}
	}

	public void AssignMonument(List<string> monumentArgs)
	{
		Monument monument = monumentFactory.CreateMonument(monumentArgs);
		string nation = monumentArgs[0];
		switch (nation)
		{
			case "Air":
				airNation.AddMonument(monument);
				break;
			case "Earth":
				earthNation.AddMonument(monument);
				break;
			case "Fire":
				fireNation.AddMonument(monument);
				break;
			case "Water":
				waterNation.AddMonument(monument);
				break;
		}
	}

	public string GetStatus(string nationsType)
	{
		StringBuilder sb = new StringBuilder();
		switch (nationsType)
		{
			case "Air":
				sb = GetStatusForParticularNation(airNation, nationsType);
				return sb.ToString().TrimEnd();
			case "Earth":
				sb = GetStatusForParticularNation(earthNation, nationsType);
				return sb.ToString().TrimEnd();
			case "Fire":
				sb = GetStatusForParticularNation(fireNation, nationsType);
				return sb.ToString().TrimEnd();
			case "Water":
				sb = GetStatusForParticularNation(waterNation, nationsType);
				return sb.ToString().TrimEnd();
			default:
				throw new ArgumentException("Not such a Nation");
		}
	}


	public void IssueWar(string nationsType)
	{
		double airNationPower = 0.0;
		double fireNationPower = 0.0;
		double earthNationPower = 0.0;
		double waterNationPower = 0.0;
		airNationPower = CalculateNationsPower(airNation);
		fireNationPower = CalculateNationsPower(fireNation);
		earthNationPower = CalculateNationsPower(earthNation);
		waterNationPower = CalculateNationsPower(waterNation);
		List<double> nationsPowerList = new List<double> { airNationPower, fireNationPower, earthNationPower, waterNationPower };
		double mostPowerful = nationsPowerList.OrderByDescending(n => n).First();
		if (mostPowerful == airNationPower)
		{
			fireNation.Clear();
			earthNation.Clear();
			waterNation.Clear();
		}
		else if (mostPowerful == earthNationPower)
		{
			airNation.Clear();
			fireNation.Clear();
			waterNation.Clear();
		}
		else if (mostPowerful == fireNationPower)
		{
			airNation.Clear();
			earthNation.Clear();
			waterNation.Clear();
		}
		else
		{
			airNation.Clear();
			fireNation.Clear();
			earthNation.Clear();
		}
		string warIssuedByToken = $"War {warsIssuedBy.Count + 1} issued by {nationsType}";
		warsIssuedBy.Add(warIssuedByToken);
	}

	private double CalculateNationsPower(Nation particularNation)
	{
		double totalPower = 0.0;
		double monumentsMultiplicator = 0.0;
		foreach (var bender in particularNation.ReadBenders)
		{
			totalPower += (bender.Power * bender.SpecialPowerMultiplicator);
		}
		foreach (var monument in particularNation.ReadMonuments)
		{
			monumentsMultiplicator += monument.Affinity;
		}
		totalPower += (totalPower * monumentsMultiplicator / 100);
		return totalPower;
	}

	public string GetWarsRecord()
	{
		StringBuilder sb = new StringBuilder();
		foreach (var war in this.warsIssuedBy)
		{
			sb.AppendLine(war);
		}
		return sb.ToString().TrimEnd();
	}

	private StringBuilder GetStatusForParticularNation(Nation particularNation, string nationType)
	{
		StringBuilder sb = new StringBuilder();
		sb.Append($"{nationType} Nation{Environment.NewLine}Benders:");
		if (particularNation.ReadBenders.Any())
		{
			sb.AppendLine();
			foreach (var bender in particularNation.ReadBenders)
			{
				sb.AppendLine(bender.ToString());
			}
		}
		else
		{
			sb.AppendLine(" None");
		}
		sb.Append("Monuments:");
		if (particularNation.ReadMonuments.Any())
		{
			sb.AppendLine();
			foreach (var monument in particularNation.ReadMonuments)
			{
				sb.AppendLine(monument.ToString());
			}
		}
		else
		{
			sb.AppendLine(" None");
		}
		return sb;
	}
}