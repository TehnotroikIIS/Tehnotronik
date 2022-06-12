using Tehnotronik.Domain.Models;

namespace Tehnotronik.MongoDB.Entities
{
    public class ShippingInformationEntity : BaseEntity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public ShippingInformation ToShippingInformation()
            => new ShippingInformation(this.Id, this.Address, this.City, this.Country, this.PhoneNumber);
        public static ShippingInformationEntity ToShippingInformationEntity(ShippingInformation shippingInformation)
        {
            return new ShippingInformationEntity
            {
                Id = shippingInformation.Id,
                Address = shippingInformation.Address,
                City = shippingInformation.City,
                Country = shippingInformation.Country,
                PhoneNumber = shippingInformation.PhoneNumber
            };
        }
    }
}
