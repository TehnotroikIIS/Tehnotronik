using System;

namespace Tehnotronik.Domain.Requests
{
    public class BlogProductRequest
    {
        public Guid BlogId { get; set; }
        public Guid ProductId { get; set; }
    }
}
