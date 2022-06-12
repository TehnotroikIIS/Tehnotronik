using System;

namespace Tehnotronik.Domain.Models
{
    public class ShippingInformation
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public ShippingInformation(Guid id, string address, string city, string country, string phoneNumber)
        {
            Id = id;
            Address = address;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
        }
    }
}
