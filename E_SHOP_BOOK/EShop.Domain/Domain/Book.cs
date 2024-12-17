﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class Book: BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double   Price { get; set; }
        public double? Rating { get; set; }
        public string? Genre { get; set; }
        public string? Image { get; set;}

        public Guid? AuthorId { get; set; }
        public Author? Author { get; set; }

        public ICollection<BookPublisher>? BookPublishers { get; set; }


    }
}
