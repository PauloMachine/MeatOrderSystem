using System.ComponentModel.DataAnnotations;

namespace MeatOrderSystem.Application.DTOs;

public class CreateOrderDto
{
    [Required(ErrorMessage = "BuyerId is required.")]
    public int BuyerId { get; set; }

    [Required(ErrorMessage = "OrderDate is required.")]
    public DateTime OrderDate { get; set; }

    [MinLength(1, ErrorMessage = "At least one item is required.")]
    public List<CreateOrderItemDto> Items { get; set; } = new();
}
