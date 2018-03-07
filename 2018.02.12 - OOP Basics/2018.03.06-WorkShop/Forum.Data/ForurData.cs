﻿using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data
{
    class ForurData
    {
		public ForurData()
		{
			this.Users = DataMapper.LoadUsers();
			this.Categories = DataMapper.LoadCategories();
			this.Posts = DataMapper.LoadPosts();
			this.Replies = DataMapper.LoadReplies();
		}

		public List<Category> Categories { get; set; }

		public List<User> Users { get; set; }

		public List<Post> Posts { get; set; }

		public List<Reply> Replies { get; set; }

		public void SaveChanges()
		{
			DataMapper.SaveCategories(this.Categories);
			DataMapper.SaveUsers(this.Users);
			DataMapper.SavePosts(this.Posts);
			DataMapper.SaveReplies(this.Replies);
		}
	}
}
