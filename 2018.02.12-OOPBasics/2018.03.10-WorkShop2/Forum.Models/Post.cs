﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Post
    {
		public Post(int id, string title, string content, int categoryId, int authorId, IEnumerable<int> replyIds)
		{
			this.Id = id;
			this.Title = title;
			this.Content = content;
			this.Categories = categoryId;
			this.Authors = authorId;
			this.Replies = new List<int>(replyIds);
		}

		public int Id { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public int Categories { get; set; }

		public int Authors { get; set; }

		public ICollection<int> Replies { get; set; }
	}
}
