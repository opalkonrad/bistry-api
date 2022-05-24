namespace BistryApi.Orders.Requests;

public class PlaceOrderRequest
{
    public int TableId { get; set; }

    public string MenuItems { get; set; }
}
