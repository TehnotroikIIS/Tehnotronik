using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("Products")]
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string TechnicalDescription { get; set; }
        public double Rate { get; set; }
        public int NumberOfReviews { get; set; }
        public bool IsAvailable { get; set; }
        public int SoldInWeek { get; set; }
        public int SoldInMonth { get; set; }
        public int SoldInYear { get; set; }
        public Product ToProduct()
            => new Product(this.Id, this.Name, this.Price, this.Description, this.Manufacturer, this.TechnicalDescription,
                this.Rate, this.NumberOfReviews, this.IsAvailable, this.SoldInWeek, this.SoldInMonth, this.SoldInYear);
        public static ProductEntity ToProductEntity(Product product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Manufacturer = product.Manufacturer,
                TechnicalDescription = product.TechnicalDescription,
                Rate = product.Rate,
                NumberOfReviews = product.NumberOfReviews,
                IsAvailable = product.IsAvailable,
                SoldInWeek = product.SoldInWeek,
                SoldInMonth = product.SoldInMonth,
                SoldInYear = product.SoldInYear
            };
        }
    }
}
