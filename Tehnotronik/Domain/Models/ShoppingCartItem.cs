using System;

namespace Tehnotronik.Domain.Models
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ShoppingCartItem(Guid id, Guid productId, double price, int quantity)
        {
            Id = id;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }
    }
}
