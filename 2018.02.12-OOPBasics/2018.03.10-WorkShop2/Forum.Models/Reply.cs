using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Reply
    {
		public Reply(int id, string content, int authorId, int postId)
		{
			this.Id = id;
			this.Content = content;
			this.Authors = authorId;
			this.Posts = postId;
		}

		public int Id { get; set; }

		public string Content { get; set; }

		public int Authors { get; set; }

		public int Posts { get; set; }
	}
}
