using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.DTO
{
    
        public class PartnerEventsViewModel
        {
            public List<PartnerEvent> Events { get; set; }
            public List<ScheduledEvent> ScheduledEvents { get; set; }
        }
   
}
