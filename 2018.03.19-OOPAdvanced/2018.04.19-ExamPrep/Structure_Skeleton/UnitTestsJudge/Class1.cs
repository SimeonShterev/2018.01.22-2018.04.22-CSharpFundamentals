using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Class1
{
	private IEnergyRepository energyRepository;
	private IProviderController providerController;

	[SetUp]
	public void Initialise()
	{
		this.energyRepository = new EnergyRepository();
		this.providerController = new ProviderController(this.energyRepository);
	}

	[Test]
	public void TestProducingEnergy()
	{
		IList<string> provider1 = new List<string>()
		{
			"Pressure", "1", "100"
		};

		this.providerController.Register(provider1);
		this.providerController.Produce();

		double energy = this.providerController.TotalEnergyProduced;
		double expectedValue = 200d;

		Assert.That(energy, Is.EqualTo(expectedValue));
	}

	[Test]
	public void TestReapirProvider()
	{
		IList<string> provider1 = new List<string>()
		{
			"Pressure", "1", "100"
		};

		this.providerController.Register(provider1);
		this.providerController.Repair(150d);

		double duranility = this.providerController.Entities.First().Durability;
		double expectedDurability = 850d;

		Assert.That(duranility, Is.EqualTo(expectedDurability));
	}

	[Test]
	public void TestBreakProvider()
	{
		IList<string> provider1 = new List<string>()
		{
			"Pressure", "1", "100"
		};

		IList<string> provider2 = new List<string>()
		{
			"Pressure", "2", "100"
		};

		this.providerController.Register(provider1);
		this.providerController.Register(provider2);

		for (int i = 0; i < 8; i++)
		{
			this.providerController.Produce();
		}

		Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
	}
}