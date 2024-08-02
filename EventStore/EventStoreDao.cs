using Domain.Entities;
using Newtonsoft.Json;

namespace EventStore;

public class EventStoreDao : IEventStore
{
    private readonly AppDbContext _context;

    public EventStoreDao()
    {
        _context = new AppDbContext();
    }

    public void SaveEvent(IEvent @event)
    {
        var eventEntity = new Event
        {
            EventId = @event.EventId,
            AggregateId = @event.GetType().Name,
            EventType = @event.GetType().Name,
            EventData = JsonConvert.SerializeObject(@event),
            Timestamp = @event.Timestamp
        };

        _context.Events.Add(eventEntity);
        _context.SaveChanges();
    }
}
