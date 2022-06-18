using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class StorageOrderRepository : IStorageOrderRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public StorageOrderRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task CreateAsync(StorageOrder order)
        {
            await _queryExecutor.CreateAsync(StorageOrderEntity.ToStorageOrderEntity(order));
        }

        public async Task<StorageOrder> GetByIdAsync(Guid id)
        {
            StorageOrderEntity orderEntity = await _queryExecutor.FindByIdAsync<StorageOrderEntity>(id);
            return orderEntity.ToStorageOrder();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var filter = Builders<StorageOrderEntity>.Filter.Eq(u => u.Id, id);
            await _queryExecutor.DeleteByIdAsync(filter);
        }

        public async Task UpdateAsync(StorageOrder order)
        {
            var filter = Builders<StorageOrderEntity>.Filter.Eq(u => u.Id, order.Id);
            var update = Builders<StorageOrderEntity>.Update
                .Set(o => o.Quantity, order.Quantity)
                .Set(o => o.Price, order.Price)
                .Set(o => o.Arrived, order.Arrived);
            await _queryExecutor.UpdateAsync(filter, update);
        }
    }
}
