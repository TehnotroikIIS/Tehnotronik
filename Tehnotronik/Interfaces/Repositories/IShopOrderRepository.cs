using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IShopOrderRepository
    {
        Task<bool> CreateAsync(ShopOrder shopOrder);
        Task<ShopOrder> GetById(Guid id);
        Task<IReadOnlyList<ShopOrder>> GetByUserId(Guid userId);
    }
}
