using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("FavoriteCategories")]
    public class FavoriteCategoriesEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid[] Categories { get; set; }
        public FavoriteCategories ToFavoriteCategories()
            => new FavoriteCategories(this.Id, this.UserId, this.Categories);
        public static FavoriteCategoriesEntity ToFavoriteCategoriesEntity(FavoriteCategories favoriteCategories)
        {
            return new FavoriteCategoriesEntity
            {
                Id = favoriteCategories.Id,
                UserId = favoriteCategories.UserId,
                Categories = favoriteCategories.Categories
            };
        }
    }
}
