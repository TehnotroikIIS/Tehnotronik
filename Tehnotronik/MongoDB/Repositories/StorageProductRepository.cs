using System;
using System.Linq;
using System.Collections.Generic;
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
        public async Task<StorageProduct> GetByProductIdAsync(Guid productId)
        {
            var filter = Builders<StorageProductEntity>.Filter.Eq(u => u.ProductId, productId);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.FirstOrDefault()?.ToStorageProduct() ?? null;
        }

        public async Task<bool> CreateStorgeComplaint(StorageComplaint storageComplaint)
        {
            await _queryExecutor.CreateAsync(StorageComplaintEntity.ToStorageComplaintEntity(storageComplaint));

            return true;
        }

        public async Task<IReadOnlyList<StorageComplaint>> GetAllStorageComplaints()
        {
            var result = await _queryExecutor.GetAll<StorageComplaintEntity>();

            return result?.Select(s => s.ToStorageComplaint())?.ToList() ?? new List<StorageComplaint>();
        }

        public async Task<bool> CreateAsync(StorageProduct storageProduct)
        {
            await _queryExecutor.CreateAsync(StorageProductEntity.ToEntity(storageProduct));

            return true;
        }

        public async Task<IReadOnlyList<StorageProduct>> GetAllStorageProducts()
        {
            var result = await _queryExecutor.GetAll<StorageProductEntity>();

            return result?.Select(s => s.ToStorageProduct())?.ToList() ?? new List<StorageProduct>();
        }

        public async Task UpdateMinimalQuantity(Guid id, int minimalQuantity)
        {
            var filter = Builders<StorageProductEntity>.Filter.Eq(u => u.Id, id);

            var update = Builders<StorageProductEntity>.Update
                .Set(u => u.MinimalQuantity, minimalQuantity);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task UpdateStoragePriority(Guid id, PriorityEnum priorityEnum)
        {
            var filter = Builders<StorageProductEntity>.Filter.Eq(u => u.Id, id);

            var update = Builders<StorageProductEntity>.Update
                .Set(u => u.Priority, priorityEnum);

            await _queryExecutor.UpdateAsync(filter, update);
        }
    }
}
