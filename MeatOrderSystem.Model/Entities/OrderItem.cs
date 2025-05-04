namespace MeatOrderSystem.Model.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int MeatId { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = string.Empty;

    public Order Order { get; set; } = null!;
    public Meat Meat { get; set; } = null!;
}