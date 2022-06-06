using System;

namespace Tehnotronik.Domain.Requests
{
    public class ProductUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string TechnicalDescription { get; set; }
    }
}
