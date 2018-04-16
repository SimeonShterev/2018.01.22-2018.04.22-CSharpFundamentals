using System;
using System.Collections.Generic;
using System.Text;

namespace Integration
{
    public class User
    {
		private string name;
		private ICollection<Category> categories;

		public User(string name)
		{
			this.name = name;
			this.categories = new HashSet<Category>();
		}

		public void AddCategoryToUser(Category category)
		{
			this.categories.Add(category);
		}
    }
}
