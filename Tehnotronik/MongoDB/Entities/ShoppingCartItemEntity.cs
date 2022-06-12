using System;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.MongoDB.Entities
{
    public class ShoppingCartItemEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ShoppingCartItem ToShoppingCartItem()
            => new ShoppingCartItem(this.Id, this.ProductId, this.Price, this.Quantity);
        public static ShoppingCartItemEntity ToShoppingCartItemEntity(ShoppingCartItem shoppingCartItem)
        {
            return new ShoppingCartItemEntity
            {
                Id = shoppingCartItem.Id,
                ProductId = shoppingCartItem.ProductId,
                Price = shoppingCartItem.Price,
                Quantity = shoppingCartItem.Quantity
            };
        }
    }
}
