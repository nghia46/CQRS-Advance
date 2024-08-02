namespace EventStore;
public interface IEvent
{
    Guid EventId { get; }
    DateTime Timestamp { get; }
}
