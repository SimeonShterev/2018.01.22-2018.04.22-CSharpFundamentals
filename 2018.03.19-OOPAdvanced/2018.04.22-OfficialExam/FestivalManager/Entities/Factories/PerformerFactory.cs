namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using System;
	using System.Linq;
	using System.Reflection;

	public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
			Assembly assembly = Assembly.GetCallingAssembly();
			Type type = assembly.GetTypes().FirstOrDefault(p => p.Name == "Performer");

			IPerformer performer = (IPerformer)Activator.CreateInstance(type, name, age);
			return performer;
		}
	}
}