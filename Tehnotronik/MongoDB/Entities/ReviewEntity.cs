using System;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.MongoDB.Entities
{
    public class ReviewEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public Review ToReview()
            => new Review(this.Id, this.UserId, this.Text, this.Rate);
        public static ReviewEntity ToReviewEntity(Review review)
        {
            return new ReviewEntity
            {
                Id = review.Id,
                Rate = review.Rate,
                Text = review.Text,
                UserId = review.UserId
            };
        }
    }
}
