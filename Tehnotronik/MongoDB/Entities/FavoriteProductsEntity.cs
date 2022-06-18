using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("FavoriteProducts")]
    public class FavoriteProductsEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid[] Products { get; set; }
        public FavoriteProducts ToFavoriteProducts()
            => new FavoriteProducts(this.Id, this.UserId, this.Products);
        public static FavoriteProductsEntity ToFavoriteProductsEntity(FavoriteProducts favoriteProducts)
        {
            return new FavoriteProductsEntity
            {
                Id = favoriteProducts.Id,
                UserId = favoriteProducts.UserId,
                Products = favoriteProducts.Products
            };
        }
    }
}
