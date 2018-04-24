using System.Collections.Generic;

public class RepairCommand : Command
{
	private IProviderController providerController;

	public RepairCommand(IList<string> args, IProviderController providerController) 
		: base(args)
	{
		this.providerController = providerController;
	}

	public override string Execute()
	{
		return this.providerController.Repair(double.Parse(this.Arguments[0]));
	}
}