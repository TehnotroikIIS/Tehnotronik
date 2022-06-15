using System;

namespace Tehnotronik.Domain.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }

        public Comment(Guid id, Guid userId, string text)
        {
            Id = id;
            UserId = userId;
            Text = text;
        }
    }
}
