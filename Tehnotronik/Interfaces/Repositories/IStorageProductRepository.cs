using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IStorageProductRepository
    {
        Task UpdateAsync(StorageProduct product);
        Task<StorageProduct> GetByIdAsync(Guid id);
        Task DeleteByIdAsync(Guid id);
        Task<bool> CreateStorgeComplaint(StorageComplaint storageComplaint);
        Task<IReadOnlyList<StorageComplaint>> GetAllStorageComplaints();
    }
}
