using MediatR;

namespace Application.Resources.Items.Commands.CreateItem;

public class CreateItemCommand() : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
