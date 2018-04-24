using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
	private IWriter writer;

	public CommandInterpreter(IEnergyRepository energyRepository, IWriter writer, IHarvesterController harvesterController, IProviderController providerController)
	{
		this.HarvesterController = harvesterController;
		this.ProviderController = providerController;
		this.writer = writer;
	}

	public IHarvesterController HarvesterController { get; }

	public IProviderController ProviderController { get; }

	public string ProcessCommand(IList<string> args)
	{
		ICommand command = CreateCommand(args);
		string result = command.Execute();
		return result;
	}

	private ICommand CreateCommand(IList<string> args)
	{
		string commandName = args[0];
		Type commandType = Type.GetType(commandName + "Command");

		ConstructorInfo ctor = commandType.GetConstructors().First();
		ParameterInfo[] parameterInfos = ctor.GetParameters();
		object[] parametersForConstructor = new object[parameterInfos.Length];

		for (int i = 0; i < parameterInfos.Length; i++)
		{
			Type typeOfParameter = parameterInfos[i].ParameterType;
			if(typeOfParameter == typeof(IList<string>))
			{
				parametersForConstructor[i] = args.Skip(1).ToList();
			}
			else if(typeOfParameter == typeof(IHarvesterController))
			{
				parametersForConstructor[i] = this.HarvesterController;
			}
			else if (typeOfParameter == typeof(IProviderController))
			{
				parametersForConstructor[i] = this.ProviderController;
			}
		}

		//ICommand command = (ICommand)ctor.Invoke(parametersForConstructor);
		ICommand command = (ICommand)Activator.CreateInstance(commandType, parametersForConstructor);
		return command;
	}
}