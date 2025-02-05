﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore
{
    public class OrderCreatedEvent : IEvent
    {
        public new Guid EventId { get; set; }
        public new DateTime Timestamp { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
