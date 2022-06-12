using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IShoppingCartRepository
    {
        Task<bool> AddToCart(Guid shoppingCartId, ShoppingCartItem shoppingCartItem);
        Task<bool> RemoveFromCart(ShoppingCart shoppingCart);
        Task<bool> CreateCart(ShoppingCart shoppingCart);
        Task<ShoppingCart> GetById(Guid id);
        Task<bool> DeleteById(Guid id);
    }
}
