using System;

namespace Tehnotronik.Domain.Requests
{
    public class ShoppingCartItemRequest
    {
        public Guid UserId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
