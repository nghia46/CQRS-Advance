using Commands.Command;
using EventStore;
using MediatR;
using WriteDbInfrastructure;

namespace Commands.Handler;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly WriteDbContext _writeDbContext;
    private readonly IEventStore _eventStore; // Inject the Event Store
    private readonly OrderEventHandler _orderEventHandler; // Inject the OrderEventHandler

    public CreateOrderHandler()
    {
        _writeDbContext = new WriteDbContext();
        _eventStore = new EventStoreDao(); // Instantiate the Event Store
        _orderEventHandler = new OrderEventHandler(); // Instantiate the OrderEventHandler
    }
    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return await Task.Run(async () =>
        {
            // Create and store the event
            var orderCreatedEvent = new OrderCreatedEvent
            {
                EventId = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                OrderId = request.Order.OrderID,
                CustomerId = request.Order.CustomerID,
                TotalAmount = request.Order.TotalAmount
            };

            _eventStore.SaveEvent(orderCreatedEvent); // Save the event to the Event Store

            // Save the order to the write database
            _writeDbContext.Orders.Add(request.Order);
            _writeDbContext.SaveChanges();

            await _orderEventHandler.Handle(orderCreatedEvent); // Handle the event
            return true;
        });
    }
}
