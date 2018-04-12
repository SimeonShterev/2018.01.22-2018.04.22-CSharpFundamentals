﻿namespace Forum.App.Factories
{
	using Contracts;
	using System;
	using System.Linq;
	using System.Reflection;

	public class CommandFactory : ICommandFactory
	{
		private IServiceProvider serviceProvider;

		public CommandFactory(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public ICommand CreateCommand(string commandName)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			Type commandType = assembly.GetTypes().FirstOrDefault(c => c.Name == $"{commandName}Command");
			
			if(commandType==null)
			{
				throw new InvalidOperationException("Command not found!");
			}
			if(!(typeof(ICommand).IsAssignableFrom(commandType)))
			{
				throw new InvalidOperationException($"{commandName} not found!");
			}

			ParameterInfo[] ctorParams = commandType.GetType().GetConstructor(new Type[] { commandType }).GetParameters();
			object[] args = new object[ctorParams.Length];

			for (int i = 0; i < args.Length; i++)
			{
				args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
			}

			ICommand command = (ICommand)Activator.CreateInstance(commandType, args);
			return command;
		}
	}
}