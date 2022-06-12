using System;

namespace Tehnotronik.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public double TotalPrice { get; set; }

        public Order(Guid id, Guid userId, Guid shoppingCartId, double totalPrice)
        {
            Id = id;
            UserId = userId;
            ShoppingCartId = shoppingCartId;
            TotalPrice = totalPrice;
        }
    }
}
