using System;

namespace Tehnotronik.Domain.Models
{
    public class OrderRecommendation
    {
        public Guid Id { get; set; }
        public Guid StorageProductId { get; set; }
        public int Deadline;
        public int Quantity;
    }
}
