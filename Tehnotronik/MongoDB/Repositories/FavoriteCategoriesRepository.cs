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
    public class FavoriteCategoriesRepository : IFavoriteCategoriesRepository
    {
        private readonly IQueryExecutor _queryExecutor;

        public FavoriteCategoriesRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<bool> Create(FavoriteCategories favoriteCategories)
        {
            await _queryExecutor.CreateAsync(FavoriteCategoriesEntity.ToFavoriteCategoriesEntity(favoriteCategories));

            return true;
        }

        public async Task<FavoriteCategories> GetByUserId(Guid userId)
        {
            var result = await _queryExecutor.FindByIdAsync<FavoriteCategoriesEntity>(userId);

            return result?.ToFavoriteCategories() ?? null;
        }

        public async Task Update(FavoriteCategories favoriteCategories)
        {
            var filter = Builders<FavoriteCategoriesEntity>.Filter.Eq(u => u.Id, favoriteCategories.Id);

            var update = Builders<FavoriteCategoriesEntity>.Update
                .Set(u => u.Categories, favoriteCategories.Categories);

            await _queryExecutor.UpdateAsync(filter, update);
        }
    }
}
