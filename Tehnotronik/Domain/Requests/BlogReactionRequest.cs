using System;

namespace Tehnotronik.Domain.Requests
{
    public class BlogReactionRequest
    {
        public Guid BlogId { get; set; }
        public Guid UserId { get; set; }
    }
}
