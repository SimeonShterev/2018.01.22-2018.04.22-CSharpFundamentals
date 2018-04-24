using System.Collections.Generic;
using System.Linq;

public abstract class Command : ICommand
{
	protected Command(IList<string> args, IManager manager)
	{
		this.Args = args;
		this.Manager = manager;
	}

	protected IList<string> Args { get; }

	public IManager Manager { get; }

	public abstract string Execute();
}