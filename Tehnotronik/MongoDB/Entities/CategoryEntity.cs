using System;
using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("Categories")]
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public Category ToCategory()
            => new Category(this.Id, this.Name);
        public static CategoryEntity ToCategoryEntity(Category category)
        {
            return new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
