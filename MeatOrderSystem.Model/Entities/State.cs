namespace MeatOrderSystem.Model.Entities;

public class State
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;

    public ICollection<City> Cities { get; set; } = new List<City>();
}