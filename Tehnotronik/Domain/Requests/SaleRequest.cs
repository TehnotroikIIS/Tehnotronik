using System;

namespace Tehnotronik.Domain.Requests
{
    public class SaleRequest
    {
        public Guid ProductId { get; set; }
        public int Discount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
