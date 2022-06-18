using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IStorageOrderRepository
    {
        Task CreateAsync(StorageOrder order);
        Task<StorageOrder> GetByIdAsync(Guid id);
        Task DeleteByIdAsync(Guid id);
        Task UpdateAsync(StorageOrder order);
        Task<IReadOnlyList<StorageOrder>> GetAllOrders();
    }
}
