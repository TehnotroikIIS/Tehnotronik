using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("Blogs")]
    public class BlogEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid[] Likes { get; set; }
        public Guid[] Dislikes { get; set; }
        public double Rate { get; set; }
        public Blog ToBlog()
            => new Blog(this.Id, this.Name, this.Text, this.Likes, this.Dislikes, this.Rate);
        public static BlogEntity ToBlogEntity(Blog blog)
        {
            return new BlogEntity
            {
                Id = blog.Id,
                Name = blog.Name,
                Text = blog.Text,
                Likes = blog.Likes,
                Dislikes = blog.Dislikes,
                Rate = blog.Rate
            };
        }

    }
}
