using System;

namespace Tehnotronik.Domain.Requests
{
    public class OrderRequest
    {
        public Guid UserId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public double TotalPrice { get; set; }
    }
}
