using System;

namespace Tehnotronik.Domain.Models
{
    public class StorageProduct
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public LocationEnum Location { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int MinimalQuantity { get; set; }
        public PriorityEnum Priority { get; set; }
        public SKUEnum SKU { get; set; }
        public int SKUCapacity { get; set; }

        public StorageProduct(Guid id, Guid productId, LocationEnum location, int quantity, int availableQuantity, 
            int minimalQuantity, PriorityEnum priority, SKUEnum sKU, int sKUCapacity)
        {
            Id = id;
            ProductId = productId;
            Location = location;
            Quantity = quantity;
            AvailableQuantity = availableQuantity;
            MinimalQuantity = minimalQuantity;
            Priority = priority;
            SKU = sKU;
            SKUCapacity = sKUCapacity;
        }
    }
}
