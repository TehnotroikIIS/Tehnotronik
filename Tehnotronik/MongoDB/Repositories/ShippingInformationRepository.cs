using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class ShippingInformationRepository : IShippingInformationRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public ShippingInformationRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task<bool> CreateAsync(ShippingInformation shippingInformation)
        {
            await _queryExecutor.CreateAsync(ShippingInformationEntity.ToShippingInformationEntity(shippingInformation));

            return true;
        }

        public async Task<ShippingInformation> GetById(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<ShippingInformationEntity>(id);

            return result?.ToShippingInformation() ?? null;
        }
    }
}
