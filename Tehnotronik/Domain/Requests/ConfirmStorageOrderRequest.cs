using System;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Domain.Requests
{
    public class ConfirmStorageOrderRequest
    {
        public Guid OrderId { get; set; }
        public LocationEnum Location { get; set; } 
    }
}
