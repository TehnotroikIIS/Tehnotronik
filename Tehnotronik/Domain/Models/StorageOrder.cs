using System;

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
    }
}
