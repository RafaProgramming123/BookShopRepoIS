using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    
        public class PartnerEvent
        {
            public string eventName { get; set; }
            public string eventDescription { get; set; }
            public string eventImage { get; set; }
            // In your sample, scheduledEvents might be null so you can decide to ignore or use it.
            public List<ScheduledEvent> scheduledEvents { get; set; }
            public Guid id { get; set; }
        }
   
}
