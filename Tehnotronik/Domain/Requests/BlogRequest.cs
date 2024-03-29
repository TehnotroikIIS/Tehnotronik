﻿using System;

namespace Tehnotronik.Domain.Requests
{
    public class BlogRequest
    {
        public string Name { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? ProductId { get; set; }
        public string Text { get; set; }
    }
}
