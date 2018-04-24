public class Assassin : Hero
{
	private const int strength = 25;
	private const int agility = 100;
	private const int intelligence = 15;
	private const int hitPoints = 150;
	private const int damage = 300;

	public Assassin(string name)
	: base(name)
	{
		this.Strength = strength;
		this.Agility = agility;
		this.Intelligence = intelligence;
		this.HitPoints = hitPoints;
		this.Damage = damage;
	}
}