namespace MeatOrderSystem.Model.Entities;

public class Order
{
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public DateTime OrderDate { get; set; }

    public Buyer Buyer { get; set; } = null!;
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}