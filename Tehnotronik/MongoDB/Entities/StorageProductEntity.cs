using System;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.MongoDB.Entities
{
    public class StorageProductEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public LocationEnum Location { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int MinimalQuantity { get; set; }
        public PriorityEnum Priority { get; set; }
        public SKUEnum SKU { get; set; }
        public int SKUCapacity { get; set; }

        public StorageProduct ToStorageProduct()
            => new StorageProduct
            {
                Id = Id,
                ProductId = ProductId,
                Location = Location,
                Quantity = Quantity,
                AvailableQuantity = AvailableQuantity,
                MinimalQuantity = MinimalQuantity,
                Priority = Priority,
                SKU = SKU,
                SKUCapacity = SKUCapacity
            };

        public static StorageProductEntity ToEntity(StorageProduct product)
        {
            return new StorageProductEntity
            {
                Id = product.Id,
                ProductId = product.ProductId,
                Location = product.Location,
                Quantity = product.Quantity,
                AvailableQuantity = product.AvailableQuantity,
                MinimalQuantity = product.MinimalQuantity,
                Priority = product.Priority,
                SKU = product.SKU,
                SKUCapacity = product.SKUCapacity
            };
        }
    }
}
