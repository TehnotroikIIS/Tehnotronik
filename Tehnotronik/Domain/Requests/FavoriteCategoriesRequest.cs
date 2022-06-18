using System;

namespace Tehnotronik.Domain.Requests
{
    public class FavoriteCategoriesRequest
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
