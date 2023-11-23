using Domain.Entities;

namespace Domain.Abstractions;

public interface IItemRepository
{
    void Insert(Item item);
    Task<Item> GetById(Guid itemId);
    Task<IEnumerable<Item>> GetAll();
}
