using Domain.Entities;
using MediatR;

namespace Application.Resources.Items.Queries.GetAllItems 
{
    public class GetAllItemsQuery : IRequest<IEnumerable<Item>>
    {
    }
}
