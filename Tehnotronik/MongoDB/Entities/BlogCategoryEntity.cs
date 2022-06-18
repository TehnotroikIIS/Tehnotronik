using Tehnotronik.Domain.Models;
using Tehnotronik.MongoDB.Attributes;

namespace Tehnotronik.MongoDB.Entities
{
    [CollectionName("BlogCategories")]
    public class BlogCategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public BlogCategory ToBlogCategory()
            => new BlogCategory(this.Id, this.Name);
        public static BlogCategoryEntity ToBlogCategoryEntity(BlogCategory category)
        {
            return new BlogCategoryEntity
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
