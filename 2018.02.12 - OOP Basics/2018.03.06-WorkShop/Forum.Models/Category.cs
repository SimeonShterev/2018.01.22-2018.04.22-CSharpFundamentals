using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Category
    {
        public Category(int id, string name, ICollection<int> postIds)
        {
            this.Id = id;
            this.Name = name;
            this.PostIds = postIds;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> PostIds { get; set; }
    }
}
