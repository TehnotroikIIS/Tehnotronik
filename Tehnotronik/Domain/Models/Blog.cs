using System;

namespace Tehnotronik.Domain.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid[] Likes { get; set; }
        public Guid[] Dislikes { get; set; }
        public double Rate { get; set; }

        public Blog(Guid id, string name, string text, Guid[] likes, Guid[] dislikes, double rate)
        {
            Id = id;
            Name = name;
            Text = text;
            Likes = likes;
            Dislikes = dislikes;
            Rate = rate;
        }
    }
}
