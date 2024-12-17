﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public  class Publisher: BaseEntity
    {
        public string? Name { get; set; }
        public string? Location { get; set; }

        public ICollection<BookPublisher>? BookPublishers { get; set; } 
    }
}