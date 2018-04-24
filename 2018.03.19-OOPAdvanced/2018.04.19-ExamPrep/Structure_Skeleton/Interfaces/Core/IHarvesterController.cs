using System.Collections.Generic;

public interface IHarvesterController : IController
{
	IReadOnlyCollection<IEntity> Entities { get; }

	double OreProduced { get; }

    string ChangeMode(string mode);
}