using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IStorageProductRepository
    {
        Task UpdateAsync(StorageProduct product);
        Task<StorageProduct> GetByIdAsync(Guid id);
    }
}
