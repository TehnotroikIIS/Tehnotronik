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
    }
}
