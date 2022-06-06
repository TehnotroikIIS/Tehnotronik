using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public ShoppingCartRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task<bool> AddToCart(Guid shoppingCartId, ShoppingCartItem shoppingCartItem)
        {
            var filter = Builders<ShoppingCartEntity>.Filter.Eq(u => u.Id, shoppingCartId);

            var update = Builders<ShoppingCartEntity>.Update
                .AddToSet(u => u.ShoppingCartItems, ShoppingCartItemEntity.ToShoppingCartItemEntity(shoppingCartItem));

            await _queryExecutor.UpdateAsync(filter, update);

            return true;
        }

        public async Task<bool> CreateCart(ShoppingCart shoppingCart)
        {
            await _queryExecutor.CreateAsync(ShoppingCartEntity.ToShoppingCartEntity(shoppingCart));

            return true;
        }

        public async Task<ShoppingCart> GetById(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<ShoppingCartEntity>(id);

            return result?.ToShoppingCart() ?? null;
        }

        public async Task<bool> RemoveFromCart(ShoppingCart shoppingCart)
        {
            var filter = Builders<ShoppingCartEntity>.Filter.Eq(u => u.Id, shoppingCart.Id);

            var update = Builders<ShoppingCartEntity>.Update
                .Set(u => u.ShoppingCartItems, shoppingCart.ShoppingCartItems.Select(s => ShoppingCartItemEntity.ToShoppingCartItemEntity(s)));

            await _queryExecutor.UpdateAsync(filter, update);

            return true;
        }
    }
}
