public class AutomaticMachine : Ammunition
{
    private const double weight = 6.3;
	private const double Wear_Level = 100 * weight;

	public override double Weight => weight;

	public override double WearLevel => Wear_Level;
}