using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Reply
    {
		public Reply(int id, int authorId, int postId, string content)
		{
			this.Id = id;
			this.AuthorId = authorId;
			this.PostId = postId;
			this.Content = content;
		}

		public int Id { get; set; }

        public int AuthorId { get; set; }

		public int PostId { get; set; }

		public string Content { get; set; }
	}
}
