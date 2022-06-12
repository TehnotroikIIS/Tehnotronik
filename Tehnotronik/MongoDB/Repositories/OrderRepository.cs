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
    public class OrderRepository : IOrderRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public OrderRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task CreateOrderAsync(Order order)
        {
            await _queryExecutor.CreateAsync(OrderEntity.ToOrderEntity(order));
        }

        public async Task<Order> GetById(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<OrderEntity>(id);

            return result?.ToOrder() ?? null;
        }

        public async Task<List<Order>> GetByUserId(Guid userId)
        {
            var filter = Builders<OrderEntity>.Filter.Eq(u => u.UserId, userId);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.Select(s => s.ToOrder())?.ToList() ?? new List<Order>();
        }
    }
}
