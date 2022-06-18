using System;

namespace Tehnotronik.Domain.Models
{
    public class FavoriteCategories
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid[] Categories { get; set; }

        public FavoriteCategories(Guid id, Guid userId, Guid[] categories)
        {
            Id = id;
            UserId = userId;
            Categories = categories;
        }
    }
}
