using System;

namespace Tehnotronik.Domain.Requests
{
    public class FavoriteProductsRequest
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
