namespace _03BarracksFactory.Core.Factories
{
	using System;
	using System.Reflection;
	using Models.Units;
	using Contracts;
	using System.Linq;

	public class UnitFactory : IUnitFactory
	{
		public IUnit CreateUnit(string unitType)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			//Type type = Type.GetType($"_03BarracksFactory.Models.Units.{unitType}");
			Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);
			IUnit unit = (IUnit)Activator.CreateInstance(type);
			return unit;
		}
	}
}
