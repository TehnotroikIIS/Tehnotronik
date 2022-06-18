using System;

namespace Tehnotronik.Domain.Requests
{
    public class FavoriteBlogRequest
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
    }
}
