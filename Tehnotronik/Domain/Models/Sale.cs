using System;

namespace Tehnotronik.Domain.Models
{
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Discount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Sale(Guid id, Guid productId, int discount, DateTime startTime, DateTime endTime)
        {
            Id = id;
            ProductId = productId;
            Discount = discount;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
