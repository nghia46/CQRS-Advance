using Domain.Entities;
using ReadDbInfastructure;

namespace EventStore;

public class OrderEventHandler
{
    private readonly ReadDbContext _readDbContext;

    public OrderEventHandler()
    {
        _readDbContext = new ReadDbContext();
    }

    public async Task Handle(OrderCreatedEvent orderCreatedEvent)
    {
        var orderView = new OrderView
        {
            OrderID = orderCreatedEvent.OrderId,
            CustomerID = orderCreatedEvent.CustomerId,
            TotalAmount = orderCreatedEvent.TotalAmount,
            Status = "Created",
            CreatedDate = orderCreatedEvent.Timestamp
        };

        _readDbContext.OrderViews.Add(orderView);
        await _readDbContext.SaveChangesAsync();
    }
}
