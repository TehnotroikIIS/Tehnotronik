using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task<Product> GetByIdAsync(Guid id);
    }
}
