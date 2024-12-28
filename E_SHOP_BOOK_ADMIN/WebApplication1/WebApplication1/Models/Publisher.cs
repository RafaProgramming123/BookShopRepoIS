using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public  class Publisher
    {
        public string? Name { get; set; }
        public string? Location { get; set; }

        public ICollection<BookPublisher>? BookPublishers { get; set; } 
    }
}
