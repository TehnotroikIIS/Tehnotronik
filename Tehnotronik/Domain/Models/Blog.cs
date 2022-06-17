using System;

namespace Tehnotronik.Domain.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? ProductId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid[] Likes { get; set; }
        public Guid[] Dislikes { get; set; }
        public double Rate { get; set; }
        public Comment[] Comments { get; set; }
        public DateTime DateOfPublishing { get; set; }
        public Blog(Guid id, string name, Guid? categoryId, Guid? productId, string text, Guid[] likes, 
            Guid[] dislikes, double rate, Comment[] comments, DateTime dateOfPublishing)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            ProductId = productId;
            Text = text;
            Likes = likes;
            Dislikes = dislikes;
            Rate = rate;
            Comments = comments;
            DateOfPublishing = dateOfPublishing;
        }
    }
}
