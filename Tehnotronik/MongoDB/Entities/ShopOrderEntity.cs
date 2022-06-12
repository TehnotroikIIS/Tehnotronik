using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("ShopOrders")]
    public class ShopOrderEntity : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public ShippingInformationEntity ShippingInformationEntity { get; set; }
        public ShopOrder ToShopOrder()
            => new ShopOrder(this.Id, this.UserId, this.OrderId, this.ShippingInformationEntity.ToShippingInformation());
        public static ShopOrderEntity ToShopOrderEntity(ShopOrder shopOrder)
        {
            return new ShopOrderEntity
            {
                Id = shopOrder.Id,
                OrderId = shopOrder.OrderId,
                UserId = shopOrder.UserId,
                ShippingInformationEntity = ShippingInformationEntity.ToShippingInformationEntity(shopOrder.ShippingInformation)
            };
        }
    }
}
