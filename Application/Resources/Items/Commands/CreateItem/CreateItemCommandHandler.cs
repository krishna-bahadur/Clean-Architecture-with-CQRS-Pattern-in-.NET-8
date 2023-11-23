using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Resources.Items.Commands.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
{
    private readonly IItemRepository _webinarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateItemCommandHandler(IItemRepository webinarRepository, IUnitOfWork unitOfWork)
    {
        _webinarRepository = webinarRepository;
        _unitOfWork=unitOfWork;
    }


    public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
       var item = new Item(Guid.NewGuid(), request.Name!, request.Description!, request.Price);

        _webinarRepository.Insert(item);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return item.Id;
    }
}
