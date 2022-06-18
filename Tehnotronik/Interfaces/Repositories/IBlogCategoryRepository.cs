using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IBlogCategoryRepository
    {
        Task<bool> CreateAsync(BlogCategory category);
        Task<List<BlogCategory>> GetAll();
        Task<BlogCategory> GetById(Guid id);
    }
}
