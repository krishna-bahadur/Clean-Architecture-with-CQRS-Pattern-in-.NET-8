using Domain.Premitives;

namespace Domain.Entities;

public sealed class Item : Entity
{
    public Item(Guid id, string name, string description, decimal price) : base(id)
    { 
        Name = name;
        Description = description;
        Price = price;
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
