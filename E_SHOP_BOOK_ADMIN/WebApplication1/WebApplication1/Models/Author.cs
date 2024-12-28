using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WWebApplication1.Models
{
    public class Author
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly? YearBorn { get; set; }

        public ICollection<Book>? Books { get; set;}
    }
}
