using System;

namespace Tehnotronik.Domain.Models
{
    public class StorageComplaint
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public LocationEnum WrongLocation { get; set; }
        public LocationEnum RightLocation { get; set; }

        public StorageComplaint(Guid id, Guid productId, LocationEnum wrongLocation, LocationEnum rightLocation)
        {
            Id = id;
            ProductId = productId;
            WrongLocation = wrongLocation;
            RightLocation = rightLocation;
        }
    }
}
