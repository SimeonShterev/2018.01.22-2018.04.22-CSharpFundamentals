using System.Collections.Generic;

public interface IHeroFactory
{
	IHero GenerateHero(IList<string> args);
}