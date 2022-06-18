using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IStorageOrderRepository
    {
        Task CreateAsync(StorageOrder order);
        Task<StorageOrder> GetByIdAsync(Guid id);
        Task DeleteByIdDeleteByIdAsync(Guid id);
        Task UpdateAsync(StorageOrder order);
    }
}
