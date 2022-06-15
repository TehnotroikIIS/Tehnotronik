using System;

namespace Tehnotronik.Domain.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }

        public Review(Guid id, Guid userId, string text, int rate)
        {
            Id = id;
            UserId = userId;
            Text = text;
            Rate = rate;
        }
    }
}
