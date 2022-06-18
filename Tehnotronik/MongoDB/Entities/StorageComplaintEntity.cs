using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("StorageComplaints")]
    public class StorageComplaintEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public LocationEnum WrongLocation { get; set; }
        public LocationEnum RightLocation { get; set; }
        public StorageComplaint ToStorageComplaint()
            => new StorageComplaint(this.Id, this.ProductId, this.WrongLocation, this.RightLocation);
        public static StorageComplaintEntity ToStorageComplaintEntity(StorageComplaint storageComplaint)
        {
            return new StorageComplaintEntity
            {
                Id = storageComplaint.Id,
                ProductId = storageComplaint.ProductId,
                WrongLocation = storageComplaint.WrongLocation,
                RightLocation = storageComplaint.RightLocation
            };
        }
    }
}
