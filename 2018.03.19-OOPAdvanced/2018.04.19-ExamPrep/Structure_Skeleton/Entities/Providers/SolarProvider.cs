public class SolarProvider : Provider
{
	private const double DurabilityAddend = 500d;

	public SolarProvider(int id, double energyOutput) 
		: base(id, energyOutput)
	{
		this.Durability += DurabilityAddend;
	}
}