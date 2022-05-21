using BistryApi.Administrator.Requests;
using BistryApi.Configuration;
using BistryApi.MenuItems;

namespace BistryApi.Administrator;

public class AdminStore : IAdminStore
{
    private readonly BistryContext _bistryContext;

    public AdminStore(BistryContext bistryContext)
    {
        _bistryContext = bistryContext;
    }

    public async Task AddMenuItemAsync(AddMenuItemRequest request)
    {
        var menuItem = new MenuItem()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Category = request.Category,
            Price = request.Price,
            Description = request.Description
        };

        _bistryContext.MenuItems.Add(menuItem);
        await _bistryContext.SaveChangesAsync();
    }

    public async Task DeleteMenuItemAsync(DeleteMenuItemRequest request)
    {
        var menuItem = new MenuItem()
        {
            Id = request.Id
        };

        _bistryContext.MenuItems.Attach(menuItem);
        _bistryContext.MenuItems.Remove(menuItem);
        await _bistryContext.SaveChangesAsync();
    }
}
