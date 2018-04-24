public class Barbarian : Hero
{
	private const int strength = 90;
	private const int agility = 25;
	private const int intelligence = 10;
	private const int hitPoints = 350;
	private const int damage = 150;

	public Barbarian(string name)
	: base(name)
	{
		this.Strength = strength;
		this.Agility = agility;
		this.Intelligence = intelligence;
		this.HitPoints = hitPoints;
		this.Damage = damage;
	}
}