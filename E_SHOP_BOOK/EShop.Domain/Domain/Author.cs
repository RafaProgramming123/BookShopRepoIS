using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class Author:BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly? YearBorn { get; set; }

        public ICollection<Book>? Books { get; set;}
    }
}
