using System;

namespace Tehnotronik.Domain.Requests
{
    public class ProductReviewRequest
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Review { get; set; }
        public int Rate { get; set; }
    }
}
