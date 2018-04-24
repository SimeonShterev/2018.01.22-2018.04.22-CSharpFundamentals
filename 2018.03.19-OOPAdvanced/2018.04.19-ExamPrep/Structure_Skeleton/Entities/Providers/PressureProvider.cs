public class PressureProvider : Provider
{
	private const double DurabilityLoss = 300d;
	private const double EnergyOutputMultiplier = 2d;

	public PressureProvider(int id, double energyOutput) 
		: base(id, energyOutput)
	{
		this.Durability -= DurabilityLoss;
		this.EnergyOutput *= EnergyOutputMultiplier;
	}
}
