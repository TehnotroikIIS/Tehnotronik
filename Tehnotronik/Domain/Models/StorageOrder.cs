using System;
using Tehnotronik.Domain.Requests;

namespace Tehnotronik.Domain.Models
{
    public class StorageOrder
    {
        public Guid Id { get; set; }
        public Guid StorageProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Arrived { get; set; }

        public StorageOrder(){}

        public StorageOrder(StorageOrderRequest request)
        {
            Id = request.Id;
            StorageProductId = request.StorageProductId;
            Quantity = request.Quantity;
            Price = request.Price;
            CreatedDate = DateTime.Now;
            DeliveryDate = request.DeliveryDate;
        }
        public StorageOrder(Guid id, Guid storageProductId, int quantity, int price, DateTime createdDate, DateTime deliveryDate, bool arrived)
        {
            Id = id;
            StorageProductId = storageProductId;
            Quantity = quantity;
            Price = price;
            CreatedDate = createdDate;
            DeliveryDate = deliveryDate;
            Arrived = arrived;
        }
    }
}



