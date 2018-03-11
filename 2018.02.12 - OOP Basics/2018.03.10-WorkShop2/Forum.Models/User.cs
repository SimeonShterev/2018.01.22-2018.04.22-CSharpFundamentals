using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class User
    {
		public User(int id, string userName, string password, IEnumerable<int> postIds)
		{
			this.Id = id;
			this.Username = userName;
			this.Password = password;
			this.Posts = new List<int>(postIds);
		}

		public int Id { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public ICollection<int> Posts { get; set; }
	}
}
