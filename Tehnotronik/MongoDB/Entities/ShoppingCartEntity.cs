using System;
using System.Linq;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("ShoppingCarts")]
    public class ShoppingCartEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public ShoppingCartItemEntity[] ShoppingCartItems { get; set; }
        public ShoppingCart ToShoppingCart()
            => new ShoppingCart(this.Id, this.UserId, this.ShoppingCartItems.Select(s => s.ToShoppingCartItem()).ToArray());
        public static ShoppingCartEntity ToShoppingCartEntity(ShoppingCart shoppingCart)
        {
            return new ShoppingCartEntity
            {
                Id = shoppingCart.Id,
                UserId = shoppingCart.UserId,
                ShoppingCartItems = shoppingCart.ShoppingCartItems.Select(s => ShoppingCartItemEntity.ToShoppingCartItemEntity(s)).ToArray()
            };
        }
    }
}
