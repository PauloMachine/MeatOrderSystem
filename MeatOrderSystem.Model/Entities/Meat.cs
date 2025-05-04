namespace MeatOrderSystem.Model.Entities;

public class Meat
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OriginId { get; set; }

    public MeatOrigin Origin { get; set; } = null!;
}