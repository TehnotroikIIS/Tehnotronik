using MongoDB.Driver;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public SaleRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task CreateAsync(Sale sale)
        {
            await _queryExecutor.CreateAsync(SaleEntity.ToSaleEntity(sale));
        }

        public async Task<List<Sale>> GetAllByProductId(Guid productId)
        {
            var filter = Builders<SaleEntity>.Filter.Eq(u => u.ProductId, productId);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.Select(u => u.ToSale())?.ToList() ?? new List<Sale>();
        }

        public async Task<Sale> GetById(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<SaleEntity>(id);

            return result?.ToSale() ?? null;
        }

        public async Task<IReadOnlyList<Sale>> GetAllAsync()
        {
            var result = await _queryExecutor.GetAll<SaleEntity>();

            return result?.Select(s => s.ToSale())?.ToList() ?? new List<Sale>();
        }
    }
}
