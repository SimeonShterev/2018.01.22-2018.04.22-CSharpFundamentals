public class EnergyRepository : IEnergyRepository
{
	private double totalEnergy;

	public double EnergyStored => this.totalEnergy;

	public void StoreEnergy(double energy)
	{
		this.totalEnergy += energy;
	}

	public bool TakeEnergy(double energyNeeded)
	{
		if(this.totalEnergy - energyNeeded <0)
		{
			return false;
		}
		this.totalEnergy -= energyNeeded;
		return true;
	}
}