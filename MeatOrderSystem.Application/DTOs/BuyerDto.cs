namespace MeatOrderSystem.Application.DTOs;

public class BuyerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public CityDto City { get; set; } = new();
}
