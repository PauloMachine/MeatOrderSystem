namespace MeatOrderSystem.Application.DTOs;

public class CityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public StateDto State { get; set; } = new();
}
