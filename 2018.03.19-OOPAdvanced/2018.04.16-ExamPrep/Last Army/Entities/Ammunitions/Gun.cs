public class Gun : Ammunition
{
	private const double weight = 1.4;
	private const double Wear_Level = 100 * weight;

	public override double Weight => weight;

	public override double WearLevel => Wear_Level;
}