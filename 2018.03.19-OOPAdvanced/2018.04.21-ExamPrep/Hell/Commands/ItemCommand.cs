using System.Collections.Generic;

public class ItemCommand : Command
{
	public ItemCommand(IList<string> args, IManager manager) 
		: base(args, manager)
	{
	}

	public override string Execute()
	{
		return this.Manager.AddItemToHero(this.Args);
	}
}