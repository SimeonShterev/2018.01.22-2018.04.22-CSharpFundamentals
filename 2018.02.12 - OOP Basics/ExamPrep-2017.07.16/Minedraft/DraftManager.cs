using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager : IDraftManager
{
	private List<Harvester> harvestersList;
	private List<Provider> providersList;
	private HarvesterFactory harvesterFactory;
	private ProviderFactory providerFactory;

	private double commonEnergyLeft;
	private double commonOreMined;
	private string mode = "Full";

	public DraftManager()
	{
		this.harvestersList = new List<Harvester>();
		this.providersList = new List<Provider>();
		this.harvesterFactory = new HarvesterFactory();
		this.providerFactory = new ProviderFactory();
	}
	public string RegisterHarvester(List<string> arguments)
	{
		try
		{
			Harvester harvester = this.harvesterFactory.CreateHarvester(arguments);
			this.harvestersList.Add(harvester);
			return harvester.RegisterHarvesterToString();
		}
		catch (ArgumentException ex)
		{
			return ex.Message;
		}
	}


	public string RegisterProvider(List<string> arguments)
	{
		try
		{
			Provider provider = this.providerFactory.CreateProvider(arguments);
			this.providersList.Add(provider);
			return provider.RegisterProviderToString();
		}
		catch (ArgumentException ex)
		{
			return ex.Message;
		}
	}

	public string Day()
	{
		double todaysProvidedEnergy = 0.0;
		double todaysMinedPlumbusOre = 0.0;
		double todaysEnergyNeeded = 0.0;
		todaysProvidedEnergy = CalculateProvidedEnergy();
		this.commonEnergyLeft += todaysProvidedEnergy;
		switch (this.mode)
		{
			case "Full":
				todaysMinedPlumbusOre = CalculateMinedOre(1);
				todaysEnergyNeeded = CalculateEnergyNeeded(1);

				break;
			case "Half":
				todaysMinedPlumbusOre = CalculateMinedOre(0.5);
				todaysEnergyNeeded = CalculateEnergyNeeded(0.6);

				break;
			case "Energy":
				todaysMinedPlumbusOre = CalculateMinedOre(0);
				todaysEnergyNeeded = CalculateEnergyNeeded(0);
				break;
		}
		StringBuilder sb = new StringBuilder();
		if (this.commonEnergyLeft >= todaysEnergyNeeded)
		{
			sb = AddMessageToBuilder(todaysProvidedEnergy, todaysMinedPlumbusOre);
			this.commonEnergyLeft -= todaysEnergyNeeded;
			this.commonOreMined += todaysMinedPlumbusOre;
		}
		else
		{
			sb = AddMessageToBuilder(todaysProvidedEnergy, 0);
		}
		return sb.ToString().TrimEnd();
	}

	public string Mode(List<string> arguments)
	{
		this.mode = arguments[0];
		string result = $"Successfully changed working mode to {this.mode} Mode";
		return result;
	}

	public string Check(List<string> arguments)
	{
		try
		{
			string id = arguments[0];
			Unit unit = (Unit)harvestersList.FirstOrDefault(h => h.Id == id) ?? providersList.FirstOrDefault(p => p.Id == id);
			if (unit != null)
			{
				return unit.ToString();
			}
			else
				throw new ArgumentException($"No element found with id - {id}");
		}
		catch (ArgumentException ex)
		{
			return ex.Message;
		}
	}

	public string ShutDown()
	{
		return "System Shutdown" + Environment.NewLine +
				$"Total Energy Stored: {this.commonEnergyLeft}" + Environment.NewLine +
				$"Total Mined Plumbus Ore: {this.commonOreMined}";
	}

	private double CalculateEnergyNeeded(double efficiency)
	{
		double todaysEnergyNeeded = 0.0;
		foreach (var harvester in harvestersList)
		{
			todaysEnergyNeeded += harvester.EnergyRequirement;
		}
		todaysEnergyNeeded *= efficiency;
		return todaysEnergyNeeded;
	}

	private double CalculateMinedOre(double efficiency)
	{
		double todaysMinedPlumbusOre = 0.0;
		foreach (var harvester in this.harvestersList)
		{
			todaysMinedPlumbusOre += harvester.OreOutput;
		}
		todaysMinedPlumbusOre *= efficiency;
		return todaysMinedPlumbusOre;
	}

	private double CalculateProvidedEnergy()
	{
		double todaysProvidedEnergy = 0.0;
		foreach (var provider in this.providersList)
		{
			todaysProvidedEnergy += provider.EnergyOutput;
		}
		return todaysProvidedEnergy;
	}

	private StringBuilder AddMessageToBuilder(double todaysProvidedEnergy, double todaysPlumbusOre)
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"A day has passed.")
			.AppendLine($"Energy Provided: {todaysProvidedEnergy}")
			.AppendLine($"Plumbus Ore Mined: {todaysPlumbusOre}");
		return sb;
	}
}