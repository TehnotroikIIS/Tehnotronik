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

        public async Task<bool> AddReviewAsync(Review review, Guid productId)
        {
            var filter = Builders<ProductReviewEntity>.Filter.Eq(u => u.ProductId, productId);

            var update = Builders<ProductReviewEntity>.Update
                .AddToSet(u => u.Reviews, ReviewEntity.ToReviewEntity(review));

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

            return result?.FirstOrDefault(s => s.ProductId == productId)?.ToProductReview() ?? null;
        }
    }
}
