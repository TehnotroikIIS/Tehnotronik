using System;

namespace Tehnotronik.Domain.Requests
{
    public class ShoppingCartRequest
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
