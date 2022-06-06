using System;

namespace Tehnotronik.Domain.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ShoppingCartItem[] ShoppingCartItems { get; set; }

        public ShoppingCart(Guid id, Guid userId, ShoppingCartItem[] shoppingCartItems)
        {
            Id = id;
            UserId = userId;
            ShoppingCartItems = shoppingCartItems;
        }
    }
}
