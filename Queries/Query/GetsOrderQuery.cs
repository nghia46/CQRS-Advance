using Domain.Entities;
using MediatR;

namespace Queries.Query;
public record GetOrdersQuery() : IRequest<IEnumerable<OrderView>>;