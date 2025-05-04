namespace MeatOrderSystem.Model.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int StateId { get; set; }

    public State State { get; set; } = null!;
    public ICollection<Buyer> Buyers { get; set; } = new List<Buyer>();
}