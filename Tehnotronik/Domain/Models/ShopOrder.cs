using System;

namespace Tehnotronik.Domain.Models
{
    public class ShopOrder
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public ShippingInformation ShippingInformation { get; set; }

        public ShopOrder(Guid id, Guid userId, Guid orderId, ShippingInformation shippingInformation)
        {
            Id = id;
            UserId = userId;
            OrderId = orderId;
            ShippingInformation = shippingInformation;
        }
    }
}
