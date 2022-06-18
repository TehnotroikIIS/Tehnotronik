using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public BlogCategoryRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task<bool> CreateAsync(BlogCategory category)
        {
            await _queryExecutor.CreateAsync(BlogCategoryEntity.ToBlogCategoryEntity(category));

            return true;
        }

        public async Task<List<BlogCategory>> GetAll()
        {
            var result = await _queryExecutor.GetAll<BlogCategoryEntity>();

            return result?.Select(s => s.ToBlogCategory())?.ToList() ?? new List<BlogCategory>();
        }

        public async Task<BlogCategory> GetById(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<BlogCategoryEntity>(id);

            return result?.ToBlogCategory() ?? null;
        }
    }
}
