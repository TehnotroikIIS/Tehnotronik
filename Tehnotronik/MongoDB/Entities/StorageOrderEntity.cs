using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("StorageOrders")]
    public class StorageOrderEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid StorageProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Arrived { get; set; }

        public StorageOrder ToStorageOrder()
            => new StorageOrder(Id, StorageProductId, Quantity, Price, CreatedDate, DeliveryDate, Arrived);

        public static StorageOrderEntity ToStorageOrderEntity(StorageOrder order)
        {
            return new StorageOrderEntity
            {
                Id = order.Id,
                StorageProductId = order.StorageProductId,
                Quantity = order.Quantity,
                Price = order.Price,
                CreatedDate = order.CreatedDate,
                DeliveryDate = order.DeliveryDate,
                Arrived = order.Arrived
            };
        }
    }
}
