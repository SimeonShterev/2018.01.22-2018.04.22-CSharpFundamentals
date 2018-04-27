using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
		private int capacity;
		private List<Item> items;

		protected Bag(int capacity)
		{
			this.capacity = capacity;
			this.items = new List<Item>();
		}

		public int Load { get; private set; }

		public IReadOnlyCollection<Item> Items => this.items;

		public void AddItem(Item item)
		{
			if(this.Load + item.Weight>this.capacity)
			{
				throw new InvalidOperationException(Consts.FullBag);
			}
			this.items.Add(item);
			this.Load += item.Weight;
		}

		public Item GetItem(string name)
		{
			if(!this.items.Any())
			{
				throw new InvalidOperationException(Consts.EmptyBag);
			}

			Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);
			if(item==null)
			{
				throw new ArgumentException(string.Format(Consts.NotSuchItem, name));
			}

			this.items.Remove(item);
			return item;
		}
	}
}
