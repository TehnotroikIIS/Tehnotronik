using System;

namespace Tehnotronik.Domain.Requests
{
    public class BlogCommentRequest
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public Guid BlogId { get; set; }
    }
}
