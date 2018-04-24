using System;
using System.Collections.Generic;

public class HeroFactory : IHeroFactory
{
	public IHero GenerateHero(IList<string> args)
	{
		string heroName = args[0];
		string heroTypeName = args[1];

		Type heroType = Type.GetType(heroTypeName);

		IHero hero = (IHero)Activator.CreateInstance(heroType, heroName);
		return hero;
	}
}