using System;

public class AmmunitionFactory : IAmmunitionFactory
{
	public IAmmunition CreateAmmunition(string ammunitionName)
	{
		Type ammunitionType = Type.GetType(ammunitionName);
		IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(ammunitionType);
		return ammunition;
	}
}