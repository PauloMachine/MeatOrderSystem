using System;

namespace MeatOrderSystem.Application.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public BuyerDto Buyer { get; set; } = new();
    public DateTime OrderDate { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}
