using System;
using System.Collections.Generic;
using System.Text;

namespace Integration
{
    public class Engine
    {
		private ICollection<Category> categories;

		public Engine()
		{
			this.categories = new HashSet<Category>();
		}

		public void AddCategories(params Category[] categories)
		{
			foreach (var category in categories)
			{
				this.categories.Add(category);
			}
		}

		public void RemoveCategories(params Category[] categories)
		{
			foreach (var category in categories)
			{
				this.categories.Remove(category);
			}
		}
    }
}
