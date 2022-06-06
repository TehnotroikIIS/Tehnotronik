using System;

namespace Tehnotronik.Domain.Models
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartItem(Guid id, Guid productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
