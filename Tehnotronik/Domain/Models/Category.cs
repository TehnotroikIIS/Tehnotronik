using System;

namespace Tehnotronik.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
