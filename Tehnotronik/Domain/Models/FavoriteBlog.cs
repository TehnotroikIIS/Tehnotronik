using System;

namespace Tehnotronik.Domain.Models
{
    public class FavoriteBlog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid[] Blogs { get; set; }

        public FavoriteBlog(Guid id, Guid userId, Guid[] blogs)
        {
            Id = id;
            UserId = userId;
            Blogs = blogs;
        }
    }
}
