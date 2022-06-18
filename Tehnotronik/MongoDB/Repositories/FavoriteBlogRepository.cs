using MongoDB.Driver;
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
    public class FavoriteBlogRepository : IFavoriteBlogRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public FavoriteBlogRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        } 
        public async Task<bool> CreateAsync(FavoriteBlog favoriteBlog)
        {
            await _queryExecutor.CreateAsync(FavoriteBlogEntity.ToFavoriteBlogEntity(favoriteBlog));

            return true;
        }

        public async Task<FavoriteBlog> GetByUserId(Guid userId)
        {
            var result = await _queryExecutor.FindByIdAsync<FavoriteBlogEntity>(userId);

            return result?.ToFavoriteBlog() ?? null;
        }

        public async Task UpdateList(FavoriteBlog favoriteBlog)
        {
            var filter = Builders<FavoriteBlogEntity>.Filter.Eq(u => u.Id, favoriteBlog.Id);

            var update = Builders<FavoriteBlogEntity>.Update
                .Set(u => u.Blogs, favoriteBlog.Blogs);

            await _queryExecutor.UpdateAsync(filter, update);
        }
    }
}
