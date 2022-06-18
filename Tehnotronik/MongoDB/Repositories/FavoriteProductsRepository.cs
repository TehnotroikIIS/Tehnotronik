using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class FavoriteProductsRepository : IFavoriteProductsRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public FavoriteProductsRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task Create(FavoriteProducts favoriteProducts)
        {
            await _queryExecutor.CreateAsync(FavoriteProductsEntity.ToFavoriteProductsEntity(favoriteProducts));
        }

        public async Task<FavoriteProducts> GetByUserId(Guid userId)
        {
            var result = await _queryExecutor.FindByIdAsync<FavoriteProductsEntity>(userId);

            return result?.ToFavoriteProducts() ?? null;
        }

        public async Task Update(FavoriteProducts favoriteProducts)
        {
            var filter = Builders<FavoriteProductsEntity>.Filter.Eq(u => u.Id, favoriteProducts.Id);

            var update = Builders<FavoriteProductsEntity>.Update
                .Set(u => u.Products, favoriteProducts.Products);

            await _queryExecutor.UpdateAsync(filter, update);
        }
    }
}
