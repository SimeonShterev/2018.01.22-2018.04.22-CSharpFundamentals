public class RPG : Ammunition
{
	public const double weight = 17.1;
	private const double Wear_Level = 100 * weight;

	public override double Weight => weight;

	public override double WearLevel => Wear_Level;
}