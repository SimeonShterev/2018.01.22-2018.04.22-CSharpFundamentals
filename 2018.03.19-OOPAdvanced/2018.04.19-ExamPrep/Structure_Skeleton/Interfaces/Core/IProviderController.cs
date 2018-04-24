using System.Collections.Generic;

public interface IProviderController : IController
{
	IReadOnlyCollection<IEntity> Entities { get; }

	double TotalEnergyProduced { get; }

    string Repair(double val);
}