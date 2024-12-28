
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string userId { get; set; }
        public EShopApplicationUser User { get; set; }
        public ICollection<BookInOrder> bookInOrders { get; set; }
    }
}
