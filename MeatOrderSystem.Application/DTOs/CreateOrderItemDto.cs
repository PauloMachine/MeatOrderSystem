using System.ComponentModel.DataAnnotations;

namespace MeatOrderSystem.Application.DTOs;

public class CreateOrderItemDto
{
    [Required(ErrorMessage = "Meat is required.")]
    public MeatSimpleDto Meat { get; set; } = new();

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Currency is required.")]
    [RegularExpression("^(BRL|USD|EUR)$", ErrorMessage = "Currency must be BRL, USD or EUR.")]
    public string Currency { get; set; } = string.Empty;
}
