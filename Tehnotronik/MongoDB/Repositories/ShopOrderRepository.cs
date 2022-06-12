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
    public class ShopOrderRepository : IShopOrderRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public ShopOrderRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task<bool> CreateAsync(ShopOrder shopOrder)
        {
            await _queryExecutor.CreateAsync(ShopOrderEntity.ToShopOrderEntity(shopOrder));

            return true;
        }

        public async Task<ShopOrder> GetById(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<ShopOrderEntity>(id);

            return result?.ToShopOrder() ?? null;
        }

        public async Task<IReadOnlyList<ShopOrder>> GetByUserId(Guid userId)
        {
            var filter = Builders<ShopOrderEntity>.Filter.Eq(u => u.UserId, userId);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.Select(s => s.ToShopOrder()).ToList() ?? new List<ShopOrder>();
        }
    }
}
