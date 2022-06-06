using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public ProductRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task CreateAsync(Product product)
        {
            await _queryExecutor.CreateAsync<ProductEntity>(ProductEntity.ToProductEntity(product));
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<ProductEntity>(id);

            return result?.ToProduct() ?? null;
        }

        public async Task UpdateAsync(Guid id, string name, double price, string description, string manufacturer, string technicalDescription)
        {

            var filter = Builders<ProductEntity>.Filter.Eq(u => u.Id, id);

            var update = Builders<ProductEntity>.Update
                .Set(u => u.Name, name)
                .Set(u => u.Price, price)
                .Set(u => u.Description, description)
                .Set(u => u.Manufacturer, manufacturer)
                .Set(u => u.TechnicalDescription, technicalDescription);

            await _queryExecutor.UpdateAsync(filter, update);
        }
    }
}
