public class Wizard : Hero
{
	private const int strength = 25;
	private const int agility = 25;
	private const int intelligence = 100;
	private const int hitPoints = 100;
	private const int damage = 250;

	public Wizard(string name)
	: base(name)
	{
		this.Strength = strength;
		this.Agility = agility;
		this.Intelligence = intelligence;
		this.HitPoints = hitPoints;
		this.Damage = damage;
	}
}