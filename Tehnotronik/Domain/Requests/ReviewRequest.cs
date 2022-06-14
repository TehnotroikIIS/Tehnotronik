using System;

namespace Tehnotronik.Domain.Requests
{
    public class ReviewRequest
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
    }
}
