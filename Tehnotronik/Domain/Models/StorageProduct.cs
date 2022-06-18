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
    }
}
