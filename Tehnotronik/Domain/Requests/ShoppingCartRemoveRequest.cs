using System;

namespace Tehnotronik.Domain.Requests
{
    public class ShoppingCartRemoveRequest
    {
        public Guid ShoppingCartItemId { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
