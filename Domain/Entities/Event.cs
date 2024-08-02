using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string? AggregateId { get; set; }
        public string? EventType { get; set; } 
        public string? EventData { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
