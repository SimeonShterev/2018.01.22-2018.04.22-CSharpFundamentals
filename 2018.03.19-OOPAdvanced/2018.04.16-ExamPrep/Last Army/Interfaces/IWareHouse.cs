public interface IWareHouse
{
	void EquipArmy(IArmy army);

	void AddWeaponsToWarehouse(string weaponName, int weaponCount);

	bool TryEquipSodier(ISoldier soldier);
}