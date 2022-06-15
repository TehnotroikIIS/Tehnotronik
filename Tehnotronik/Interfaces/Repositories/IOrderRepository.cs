using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task<Order> GetById(Guid id);
        Task<List<Order>> GetByUserId(Guid userId);
    }
}
