using System;

public class SoldierFactory : ISoldierFactory
{
	public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
	{
		Type soldierType = Type.GetType(soldierTypeName);
		ISoldier soldier = (ISoldier)Activator.CreateInstance(soldierType, name, age, experience, endurance);
		return soldier;
	}
}