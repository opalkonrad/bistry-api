using BistryApi.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BistryApi.MenuItems;

public class MenuItemsStore : IMenuItemsStore
{
    private readonly BistryContext _bistryContext;

    public MenuItemsStore(BistryContext bistryContext)
    {
        _bistryContext = bistryContext;
    }

    public async Task<IEnumerable<MenuItem>> GetAllAsync()
    {
        return await _bistryContext.MenuItems.ToListAsync();
    }
}
