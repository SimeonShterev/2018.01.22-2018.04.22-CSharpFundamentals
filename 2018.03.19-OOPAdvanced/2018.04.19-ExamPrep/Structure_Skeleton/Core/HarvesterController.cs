using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
	private const double EnergyModeMultiplier = 0.2;
	private const double HalfModeMultiplier = 0.5;
	private const double FullModeMultiplier = 1.0;
	private const int NoneOreProduced = 0;
	private const double DefaultModeMultiplier = 1.0;

	private IHarvesterFactory harvesterFactory;
	private IEnergyRepository energyRepository;
	private List<IHarvester> harvesters;
	private double multiplier;

	public HarvesterController(IEnergyRepository energyRepository)
	{
		this.harvesters = new List<IHarvester>();
		this.harvesterFactory = new HarvesterFactory();

		this.energyRepository = energyRepository;
		this.multiplier = DefaultModeMultiplier;
	}
	public double OreProduced { get; private set; }

	public IReadOnlyCollection<IEntity> Entities => this.harvesters;

	public string ChangeMode(string mode)
	{
		switch (mode)
		{
			case "Energy":
				this.multiplier = EnergyModeMultiplier;
				break;
			case "Half":
				this.multiplier = HalfModeMultiplier;
				break;
			case "Full":
				this.multiplier = FullModeMultiplier;
				break;
		}

		List<IHarvester> reminder = new List<IHarvester>();

		foreach (var harvester in this.harvesters)
		{
			try
			{
				harvester.Broke();
			}
			catch (Exception)
			{
				reminder.Add(harvester);
			}
		}

		foreach (var entity in reminder)
		{
			this.harvesters.Remove(entity);
		}

		return string.Format(Constants.ModeChanged, mode);
	}

	public string Produce()
	{
		double energyNeeded = this.harvesters.Select(h => h.EnergyRequirement).Sum();
		bool validEnergyRequirement = this.energyRepository.TakeEnergy(energyNeeded * this.multiplier);
		if (!validEnergyRequirement)
		{
			return string.Format(Constants.OreOutputToday, NoneOreProduced);
		}

		double oreProduced = this.harvesters.Select(n => n.Produce()).Sum() * this.multiplier;
		this.OreProduced += oreProduced;

		return string.Format(Constants.OreOutputToday, oreProduced);
	}

	public string Register(IList<string> args)
	{
		IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);
		this.harvesters.Add(harvester);
		return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
	}
}
