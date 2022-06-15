using System;

namespace Tehnotronik.Domain.Models
{
    public class ProductReview
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Review[] Reviews { get; set; }

        public ProductReview(Guid id, Guid productId, Review[] reviews)
        {
            Id = id;
            ProductId = productId;
            Reviews = reviews;
        }
    }
}
