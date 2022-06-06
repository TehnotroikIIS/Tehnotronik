using System;

namespace Tehnotronik.Domain.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string TechnicalDescription { get; set; }
        public Guid CategoryId { get; set; }
        public double Rate { get; set; }
        public int NumberOfReviews { get; set; }
        public bool IsAvailable { get; set; }
    }
}
