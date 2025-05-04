using System.ComponentModel.DataAnnotations;

namespace MeatOrderSystem.Application.DTOs;

public class CreateBuyerDto
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Document is required.")]
    [StringLength(20, ErrorMessage = "Document must be at most 20 characters.")]
    public string Document { get; set; } = string.Empty;

    [Required(ErrorMessage = "CityId is required.")]
    public int CityId { get; set; }
}
