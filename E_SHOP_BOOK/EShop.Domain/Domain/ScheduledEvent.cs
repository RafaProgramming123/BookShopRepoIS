using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class ScheduledEvent
    {
        public DateTime scheduledEventDateTime { get; set; }
        public string scheduledEventLocation { get; set; }
        public string scheduledEventImage { get; set; }
        public Guid eventId { get; set; }
        // Note: since “event” is a reserved word, we use @event to store the related event details.
        public PartnerEvent @event { get; set; }
        public string eventNameDisplay { get; set; }
        public Guid id { get; set; }
    }
}
