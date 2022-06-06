using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        Task CreateAsync(Sale sale);
        Task<List<Sale>> GetAllByProductId(Guid productId);
        Task<Sale> GetById(Guid id);
    }
}
