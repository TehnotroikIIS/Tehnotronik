using System;

namespace Tehnotronik.Domain.Requests
{
    public class MinimalQuantityRequest
    {
        public Guid StorageProductId { get; set; }
        public int MinimalQuantity { get; set; }
    }
}
