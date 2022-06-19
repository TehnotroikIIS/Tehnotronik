using System;

namespace Tehnotronik.Domain.Requests
{
    public class StorageProductQuantityRequest
    {
        public Guid StorageProductId { get; set; }
        public int NewQuantity { get; set; }
    }
}
