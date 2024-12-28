using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BookPublisher
    {
        public Guid? BookId { get; set; }
        public Book? Book { get; set; }
        public Guid? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
