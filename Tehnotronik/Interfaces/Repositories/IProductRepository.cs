using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task<Product> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, string name, double price, string description, string manufacturer, string technicalDescription);
        Task UpdateAvailabilityById(Guid id, bool isAvailable);
        Task<List<Product>> GetByCategoryId(Guid categoryId);
        Task<List<Product>> SearchByName(string name);
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<IReadOnlyList<Product>> GetAllBetweenPricesAsync(double minPrice, double maxPrice);
        Task<IReadOnlyList<Product>> GetAllAvailableAsync();
    }
}
