using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
	private IProviderController providerController;
	private IHarvesterController harvesterController;

	public InspectCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
		: base(args)
	{
		this.providerController = providerController;
		this.harvesterController = harvesterController;
	}

	public override string Execute()
	{
		IEntity entity = null;
		int id = int.Parse(this.Arguments[0]);

		entity = providerController.Entities.FirstOrDefault(p => p.ID == id);
		if(entity==null)
		{
			entity = this.harvesterController.Entities.FirstOrDefault(h => h.ID == id);
		}

		if(entity == null)
		{
			return string.Format(Constants.InspectCommandUnsuccessful, id);
		}
		else
		{
			return entity.ToString();
		}
	}
}