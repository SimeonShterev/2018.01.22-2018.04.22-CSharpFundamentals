using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Post
    {
        public Post(int id, string title, string content, int categoryId)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }
    }
}
