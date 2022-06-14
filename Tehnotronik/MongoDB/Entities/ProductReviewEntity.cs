using System;
using System.Linq;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("ProductReviews")]
    public class ProductReviewEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public ReviewEntity[] Reviews { get; set; }
        public ProductReview ToProductReview()
            => new ProductReview(this.Id, this.ProductId, this.Reviews.Select(s => s.ToReview()).ToArray());
        public static ProductReviewEntity ToProductReviewEntity(ProductReview productReview)
        {
            return new ProductReviewEntity
            {
                Id = productReview.Id,
                ProductId = productReview.ProductId,
                Reviews = productReview.Reviews.Select(s => ReviewEntity.ToReviewEntity(s)).ToArray()
            };
        }
    }
}
