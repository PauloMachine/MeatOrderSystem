namespace MeatOrderSystem.Model.Entities;

public class Buyer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public int CityId { get; set; }

    public City City { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}