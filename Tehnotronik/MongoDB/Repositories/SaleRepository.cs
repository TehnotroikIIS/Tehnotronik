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
    }
}
