using System;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Domain.Requests
{
    public class StorageComplaintRequest
    {
        public Guid ProductId { get; set; }
        public LocationEnum WrongLocation { get; set; }
        public LocationEnum RightLocation { get; set; }
    }
}
