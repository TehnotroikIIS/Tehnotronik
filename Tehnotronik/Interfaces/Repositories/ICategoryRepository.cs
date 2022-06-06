using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<bool> CreateAsync(Category category);
        Task<List<Category>> GetAll();
        Task<Category> GetById(Guid id);
    }
}
