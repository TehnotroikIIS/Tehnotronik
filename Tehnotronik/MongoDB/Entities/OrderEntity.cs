using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("Orders")]
    public class OrderEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public double TotalPrice { get; set; }
        public Order ToOrder()
            => new Order(this.Id, this.UserId, this.ShoppingCartId, this.TotalPrice);
        public static OrderEntity ToOrderEntity(Order order)
        {
            return new OrderEntity
            {
                Id = order.Id,
                UserId = order.UserId,
                ShoppingCartId = order.ShoppingCartId,
                TotalPrice = order.TotalPrice
            };
        }
    }
}
