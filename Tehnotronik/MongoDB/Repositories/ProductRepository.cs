using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;
using System.Linq;
using MongoDB.Bson;
using System.Text.RegularExpressions;

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

        public async Task<List<Product>> GetByCategoryId(Guid categoryId)
        {
            var filter = Builders<ProductEntity>.Filter.Eq(u => u.CategoryId, categoryId);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.Select(u => u.ToProduct())?.ToList() ?? new List<Product>();
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

        public async Task UpdateAvailabilityById(Guid id, bool isAvailable)
        {
            var filter = Builders<ProductEntity>.Filter.Eq(u => u.Id, id);

            var update = Builders<ProductEntity>.Update
                .Set(u => u.IsAvailable, isAvailable);

            await _queryExecutor.UpdateAsync(filter, update);
        }
        public async Task<List<Product>> SearchByName(string name)
        {
            var filter = Builders<ProductEntity>.Filter.Regex("Name", BsonRegularExpression.Create(new Regex(name, RegexOptions.IgnoreCase)));

            var result = await _queryExecutor.FindAsync(filter);

            return result?.Select(s => s.ToProduct()).ToList() ?? new List<Product>();
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var result = await _queryExecutor.GetAll<ProductEntity>();

            return result?.Select(s => s.ToProduct())?.ToList() ?? new List<Product>();
        }

        public async Task<IReadOnlyList<Product>> GetAllBetweenPricesAsync(double minPrice, double maxPrice)
        {
            var filter = Builders<ProductEntity>.Filter.Where(u => u.Price >= minPrice && u.Price <= maxPrice);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.Select(s => s.ToProduct())?.ToList() ?? new List<Product>();
        }

        public async Task<IReadOnlyList<Product>> GetAllAvailableAsync()
        {
            var filter = Builders<ProductEntity>.Filter.Eq(u => u.IsAvailable, true);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.Select(s => s.ToProduct()).ToList() ?? new List<Product>();
        }
    }
}
