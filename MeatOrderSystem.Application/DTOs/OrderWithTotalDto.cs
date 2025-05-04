namespace MeatOrderSystem.Application.DTOs;

public class OrderWithTotalDto : OrderDto
{
    public decimal TotalInBRL { get; set; }
}
