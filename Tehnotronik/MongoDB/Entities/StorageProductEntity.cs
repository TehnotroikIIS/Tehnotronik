using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("StorageProducts")]
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
            => new StorageProduct(this.Id, this.ProductId, this.Location, this.Quantity, this.AvailableQuantity, this.MinimalQuantity, this.Priority, this.SKU, this.SKUCapacity);
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
