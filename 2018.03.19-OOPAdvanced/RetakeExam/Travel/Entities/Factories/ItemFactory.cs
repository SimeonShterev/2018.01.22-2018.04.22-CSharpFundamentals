namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
	using System;
	using System.Linq;
	using System.Reflection;

	public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string itemType)
		{
			Type type = Assembly.GetCallingAssembly().GetTypes().First(i => i.Name == itemType);
			IItem item = (IItem)Activator.CreateInstance(type);

			return item;
		}
	}
}
