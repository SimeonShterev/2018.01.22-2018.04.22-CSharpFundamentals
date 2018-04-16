public class Knife : Ammunition
{
	public const double weight = 0.4;
	private const double Wear_Level = 100 * weight;

	public override double Weight => weight;

	public override double WearLevel => Wear_Level;
}