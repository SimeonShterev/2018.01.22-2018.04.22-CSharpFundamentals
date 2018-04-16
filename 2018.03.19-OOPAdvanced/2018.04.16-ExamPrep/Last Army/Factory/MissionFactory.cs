using System;

public class MissionFactory : IMissionFactory
{
	public IMission CreateMission(string difficultyLevel, double neededPoints)
	{
		Type misssionType = Type.GetType(difficultyLevel);
		IMission mission = (IMission)Activator.CreateInstance(misssionType, neededPoints);
		return mission;
	}
}