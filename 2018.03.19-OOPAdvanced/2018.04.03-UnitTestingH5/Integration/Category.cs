using System;
using System.Collections.Generic;
using System.Text;

namespace Integration
{
    public class Category
    {
		private string name;
		private ICollection<User> users;
		private ICollection<Category> childCategories;

		public Category(string name)
		{
			this.name = name;
			this.users = new HashSet<User>();
			this.childCategories = new HashSet<Category>();
		}

		public void AssignChildCategory(Category category)
		{
			this.childCategories.Add(category);
		}

		public void AsignUser(User user)
		{
			this.users.Add(user);
			user.AddCategoryToUser(this);
		}
    }
}
