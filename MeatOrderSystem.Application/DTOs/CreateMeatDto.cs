using System.ComponentModel.DataAnnotations;

namespace MeatOrderSystem.Application.DTOs;

public class CreateMeatDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(60)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(100, ErrorMessage = "Description must be at most 100 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "OriginId is required.")]
    public int OriginId { get; set; }
}
