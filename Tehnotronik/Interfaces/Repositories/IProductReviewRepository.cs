using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IProductReviewRepository
    {
        Task<bool> CreateAsync(ProductReview productReview);
        Task<ProductReview> GetByProductId(Guid productId);
        Task<bool> AddReviewAsync(ProductReview productReview);
    }
}
