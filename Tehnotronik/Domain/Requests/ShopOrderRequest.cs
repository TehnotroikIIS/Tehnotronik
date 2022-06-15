using System;

namespace Tehnotronik.Domain.Requests
{
    public class ShopOrderRequest
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
