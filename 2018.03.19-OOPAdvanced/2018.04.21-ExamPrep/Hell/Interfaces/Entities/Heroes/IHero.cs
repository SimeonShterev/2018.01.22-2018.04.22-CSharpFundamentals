public interface IHero
{
	IInventory Inventory { get; }

	string Name { get; }

	int Strength { get; }

	int Agility { get; }

	int Intelligence { get; }

	int HitPoints { get; }

	int Damage { get; }

	string FinalOutput();
}