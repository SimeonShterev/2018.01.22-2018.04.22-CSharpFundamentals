using System.Collections.Generic;

public class RegisterCommand : Command
{
	private IProviderController providerController;
	private IHarvesterController harvesterController;

	public RegisterCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController) 
		: base(args)
	{
		this.providerController = providerController;
		this.harvesterController = harvesterController;
	}

	public override string Execute()
	{
		string result = null;
		if (this.Arguments[0] == "Harvester")
		{
			result = this.harvesterController.Register(this.Arguments);
		}
		else if(this.Arguments[0] == "Provider")
		{
			result = this.providerController.Register(this.Arguments);
		}
		return result;
	}
}
