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
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly IQueryExecutor _queryExecutor;

        public async Task<bool> AddReviewAsync(ProductReview productReview)
        {
            var filter = Builders<ProductReviewEntity>.Filter.Eq(u => u.ProductId, productReview.ProductId);

            var update = Builders<ProductReviewEntity>.Update
                .Set(u => u.Reviews, productReview.Reviews.Select(s => ReviewEntity.ToReviewEntity(s)).ToArray());

            await _queryExecutor.UpdateAsync(filter, update);

            return true;
        }

        public async Task<bool> CreateAsync(ProductReview productReview)
        {
            await _queryExecutor.CreateAsync(ProductReviewEntity.ToProductReviewEntity(productReview));

            return true;
        }

        public async Task<ProductReview> GetByProductId(Guid productId)
        {
            var filter = Builders<ProductReviewEntity>.Filter.Eq(u => u.ProductId, productId);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.FirstOrDefault()?.ToProductReview() ?? null;
        }
    }
}
