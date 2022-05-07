namespace BistryApi.MenuItems;

public class MenuItem
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Category { get; set; }

    public double Price { get; set; }

    public string Description { get; set; }
}
