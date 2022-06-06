using System;

namespace Tehnotronik.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string TechnicalDescription { get; set; }
        public Guid CategoryId { get; set; }
        public double Rate { get; set; }
        public int NumberOfReviews { get; set; }
        public bool IsAvailable { get; set; }
        public int SoldInWeek { get; set; }
        public int SoldInMonth { get; set; }
        public int SoldInYear { get; set; }

        public Product(Guid id, string name, double price, string description, string manufacturer, string technicalDescription, 
            Guid categoryId, double rate, int numberOfReviews, bool isAvailable, int soldInWeek, int soldInMonth, int soldInYear)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Manufacturer = manufacturer;
            TechnicalDescription = technicalDescription;
            CategoryId = categoryId;
            Rate = rate;
            NumberOfReviews = numberOfReviews;
            IsAvailable = isAvailable;
            SoldInWeek = soldInWeek;
            SoldInMonth = soldInMonth;
            SoldInYear = soldInYear;
        }
    }
}
