namespace _03BarracksFactory.Core
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;

	class Engine : IRunnable
	{
		private IRepository repository;
		private IUnitFactory unitFactory;

		public Engine(IRepository repository, IUnitFactory unitFactory)
		{
			this.repository = repository;
			this.unitFactory = unitFactory;
		}

		public void Run()
		{
			while (true)
			{
				try
				{
					string input = Console.ReadLine();
					string[] data = input.Split();
					string commandName = data[0];
					string result = InterpredCommand(data, commandName);
					Console.WriteLine(result);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}

		private string InterpredCommand(string[] data, string commandName)
		{
			Assembly assembly = Assembly.GetCallingAssembly();
			Type type = assembly.GetTypes()
				.FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

			if (type == null)
			{
				throw new ArgumentException("Invalid unit type");
			}
			if (!typeof(IExecutable).IsAssignableFrom(type))
			{
				throw new ArgumentException($"{commandName} is not a command!");
			}

			object[] parameters = new object[] { data, this.repository, this.unitFactory };
			object instance = Activator.CreateInstance(type, parameters);
			try
			{
				string output = (string)type
						.GetMethods()
						.First()
						.Invoke(instance, null);
				return output;
			}
			catch (Exception ex)
			{
				throw ex.InnerException;
			}
		}
	}
}
