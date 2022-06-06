using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;
using MongoDB.Driver;

namespace Tehnotronik.MongoDB.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public CategoryRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task<bool> CreateAsync(Category category)
        {
            await _queryExecutor.CreateAsync(CategoryEntity.ToCategoryEntity(category));

            return true;
        }

        public async Task<List<Category>> GetAll()
        {
            var result = await _queryExecutor.GetAll<CategoryEntity>();

            return result?.Select(s => s.ToCategory())?.ToList() ?? new List<Category>();
        }

        public async Task<Category> GetById(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<CategoryEntity>(id);

            return result?.ToCategory() ?? null;
        }
    }
}
