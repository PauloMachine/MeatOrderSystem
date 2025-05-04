namespace MeatOrderSystem.Application.DTOs;

public class OrderItemDto
{
    public MeatDto Meat { get; set; } = new();
    public decimal Price { get; set; }
    public string Currency { get; set; } = string.Empty;
}
