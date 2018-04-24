using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
			Assembly assembly = Assembly.GetCallingAssembly();
			Type setType = assembly.GetTypes().FirstOrDefault(i => i.Name == type);

			ISet set = (ISet)Activator.CreateInstance(setType, name);
			return set;
		}
	}
}
