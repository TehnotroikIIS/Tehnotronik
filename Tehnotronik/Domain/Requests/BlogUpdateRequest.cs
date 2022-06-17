using System;

namespace Tehnotronik.Domain.Requests
{
    public class BlogUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
