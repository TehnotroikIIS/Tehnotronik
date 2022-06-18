using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("FavoriteBlogs")]
    public class FavoriteBlogEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid[] Blogs { get; set; }
        public FavoriteBlog ToFavoriteBlog()
            => new FavoriteBlog(this.Id, this.UserId, this.Blogs);
        public static FavoriteBlogEntity ToFavoriteBlogEntity(FavoriteBlog favoriteBlog)
        {
            return new FavoriteBlogEntity
            {
                Id = favoriteBlog.Id,
                UserId = favoriteBlog.UserId,
                Blogs = favoriteBlog.Blogs
            };
        }
    }
}
