using System;

namespace Tehnotronik.Domain.Models
{
    public class BlogCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public BlogCategory(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
