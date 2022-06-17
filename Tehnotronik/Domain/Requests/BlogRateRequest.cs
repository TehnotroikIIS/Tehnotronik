using System;

namespace Tehnotronik.Domain.Requests
{
    public class BlogRateRequest
    {
        public Guid BlogId { get; set; }
        public int Rate { get; set; }
    }
}
