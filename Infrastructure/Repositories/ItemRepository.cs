using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _context;

    public ItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetAll()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item> GetById(Guid Id)
    {
        var item = await _context.Items.SingleOrDefaultAsync(x => x.Id == Id);
        if (item is null)
            return default!;
        return item;
    }

    public void Insert(Item item)
    {
         _context.Items.Add(item);
    }
}
