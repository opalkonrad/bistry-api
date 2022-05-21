namespace BistryApi.Administrator.Requests;

public class AddMenuItemRequest
{
    public string Name { get; set; }

    public string Category { get; set; }

    public double Price { get; set; }

    public string Description { get; set; }
}
