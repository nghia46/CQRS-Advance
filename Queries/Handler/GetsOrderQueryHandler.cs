using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Queries.Query;
using ReadDbInfastructure;
namespace Queries.Handler;

public class GetsOrderQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderView>>
{
    private readonly ReadDbContext _readDbContext;
    public GetsOrderQueryHandler()
    {
        _readDbContext = new ReadDbContext();
    }
    public async Task<IEnumerable<OrderView>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _readDbContext.OrderViews.ToListAsync();
    }
}