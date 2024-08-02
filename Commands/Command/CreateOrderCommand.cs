using Domain.Entities;
using MediatR;

namespace Commands.Command;

public record CreateOrderCommand(Order Order) : IRequest<bool>;
