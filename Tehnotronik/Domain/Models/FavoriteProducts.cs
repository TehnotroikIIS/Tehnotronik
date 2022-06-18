using System;

namespace Tehnotronik.Domain.Models
{
    public class FavoriteProducts
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid[] Products { get; set; }

        public FavoriteProducts(Guid id, Guid userId, Guid[] products)
        {
            Id = id;
            UserId = userId;
            Products = products;
        }
    }
}
