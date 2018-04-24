using System;
using System.Collections.Generic;

public class DayCommand : Command
{
	private IProviderController providerController;
	private IHarvesterController harvesterController;

	public DayCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
		: base(args)
	{
		this.providerController = providerController;
		this.harvesterController = harvesterController;
	}

	public override string Execute()
	{
		return this.providerController.Produce() + Environment.NewLine + this.harvesterController.Produce();
	}
}