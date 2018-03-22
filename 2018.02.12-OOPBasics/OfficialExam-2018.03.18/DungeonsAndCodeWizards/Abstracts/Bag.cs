using DungeonsAndCodeWizards.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Abstracts
{
    public abstract class Bag : IBag
    {
		public int currentWeightOfBag;
		public List<Item> itemsInTheBag;

		protected Bag(int capacity)
		{
			this.Capacity = capacity;
			this.itemsInTheBag = new List<Item>();
		}

		public int Capacity { get; }

		public int Load => this.currentWeightOfBag;

		public IReadOnlyCollection<Item> Items => itemsInTheBag;

		public void AddItem(Item item)
		{
			bool isFull = item.Weight + this.currentWeightOfBag > this.Capacity;
			if(isFull)
			{
				throw new InvalidOperationException(ErrorMessages.FullBag);
			}
			this.currentWeightOfBag += item.Weight;
			this.itemsInTheBag.Add(item);
		}

		public Item GetItem(string name)
		{
			bool isEmpty = !this.Items.Any();
			if(isEmpty)
			{
				throw new InvalidOperationException(ErrorMessages.EmptyBag);
			}
			Item item = this.Items.FirstOrDefault(i => i.Name == name);
			bool doesntContainItem = !this.Items.Contains(item);
			if(doesntContainItem)
			{
				throw new ArgumentException(string.Format(ErrorMessages.NotSuchAnItemIntTheBag, name));
			}
			return item;
		}

	}
}
