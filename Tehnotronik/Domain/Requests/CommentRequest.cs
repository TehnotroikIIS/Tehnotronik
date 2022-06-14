using System;

namespace Tehnotronik.Domain.Requests
{
    public class CommentRequest
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public string Text { get; set; }
    }
}
