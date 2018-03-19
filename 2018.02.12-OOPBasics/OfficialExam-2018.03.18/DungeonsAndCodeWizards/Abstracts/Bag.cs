using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DungeonsAndCodeWizards.Abstracts
{
	public abstract class Bag
	{
		private List<Item> itemsInBag;

		protected Bag(int capacity)
		{
			this.Capacity = capacity;
		}

		public int Capacity { get; }

		//public int Load =>  || 
		//public int Load 
		//{ 
		//	get
		//	{
		//		return //nqkakvo value
		//	}
		//} 

		public int Load => this.itemsInBag.Sum(i => i.Weight);

		public IReadOnlyCollection<Item> Items => this.itemsInBag;

		public void AddItem(Item item)
		{
			double bagNewWeight = this.Load + item.Weight;
			if (bagNewWeight > this.Capacity)
			{
				throw new ArgumentException();
			}
			this.itemsInBag.Add(item);

			bool checkFull = this.Capacity - this.Load <= 5;
			if (checkFull)
			{
				this.Load += 5;
				this.itemsInBag.Add(item);
			}
			else
			{
				throw new ArgumentException(ErrorMessages.FullBag);
			}
		}

		public Item GetItem(string name)
		{
			Item item = this.itemsInBag.Find(i => i.Name == name);
			this.itemsInBag.Remove(item);
			return item;
		}

		public bool CheckForItem(string name)
		{
			Item item = itemsInBag.Find(i => i.Name == name);
			if (itemsInBag.Contains(item))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
