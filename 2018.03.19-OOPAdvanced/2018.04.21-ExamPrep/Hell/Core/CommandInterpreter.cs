using System;
using System.Collections.Generic;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
	private IManager manager;

	public CommandInterpreter(IManager heroManager)
	{
		this.manager = heroManager;
	}

	public string ProcessCommand(IList<string> args)
	{
		string commandName = args[0] + "Command";
		args.RemoveAt(0);

		Type commandType = Type.GetType(commandName);
		ConstructorInfo ctor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IManager) });
		ICommand command = (ICommand)ctor.Invoke(new object[] { args, this.manager });

		return command.Execute();
	}
}