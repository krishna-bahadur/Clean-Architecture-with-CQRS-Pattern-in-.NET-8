using Domain.Entities;
using MediatR;

namespace Application.Resources.Items.Queries.GetItemById;

//public sealed record GetItemByIdQuery : IRequest<Item>
//{
//    public Guid Id { get; set; }
//}

public sealed record GetItemByIdQuery(Guid itemId) : IRequest<Item>;

