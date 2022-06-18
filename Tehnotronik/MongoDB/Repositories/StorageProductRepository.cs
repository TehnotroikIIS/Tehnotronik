using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class StorageProductRepository : IStorageProductRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public StorageProductRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task UpdateAsync(StorageProduct product)
        {
            var filter = Builders<StorageProductEntity>.Filter.Eq(p => p.Id, product.Id);
            var update = Builders<StorageProductEntity>.Update
                .Set(p => p.Quantity, product.Quantity)
                .Set(p => p.AvailableQuantity, product.AvailableQuantity)
                .Set(p => p.MinimalQuantity, product.MinimalQuantity)
                .Set(p => p.Location, product.Location)
                .Set(p => p.Priority, product.Priority)
                .Set(p => p.SKU, product.SKU)
                .Set(p => p.SKUCapacity, product.SKUCapacity);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var filter = Builders<StorageProductEntity>.Filter.Eq(p => p.Id, id);
            await _queryExecutor.DeleteByIdAsync(filter);
        }

        public async Task<StorageProduct> GetByIdAsync(Guid id)
        {
            var productEntity = await _queryExecutor.FindByIdAsync<StorageProductEntity>(id);
            return productEntity.ToStorageProduct();
        }


    }
}
