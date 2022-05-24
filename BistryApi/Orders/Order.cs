namespace BistryApi.Orders;

public class Order
{
    public Guid Id { get; set; }

    public int TableId { get; set; }

    public string MenuItems { get; set; }
}
