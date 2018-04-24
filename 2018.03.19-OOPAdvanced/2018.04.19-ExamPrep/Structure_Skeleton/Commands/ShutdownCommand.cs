using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
	private IProviderController providerController;
	private IHarvesterController harvesterController;

	public ShutdownCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
		: base(args)
	{
		this.providerController = providerController;
		this.harvesterController = harvesterController;
	}

	public override string Execute()
	{
		StringBuilder builder = new StringBuilder();

		builder.AppendLine(Constants.SystemShutdown);
		builder.AppendLine(string.Format(Constants.TotalEneryProduced, this.providerController.TotalEnergyProduced));
		builder.AppendLine(string.Format(Constants.TotalOreMined, this.harvesterController.OreProduced));

		return builder.ToString().Trim();
	}
}