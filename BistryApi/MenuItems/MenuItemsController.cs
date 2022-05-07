using Microsoft.AspNetCore.Mvc;

namespace BistryApi.MenuItems;

[Route("[controller]")]
[ApiController]
public class MenuItemsController : ControllerBase
{
    private readonly IMenuItemsStore _menuItemsStore;

    public MenuItemsController(IMenuItemsStore menuItemsStore)
    {
        _menuItemsStore = menuItemsStore;
    }

    [HttpGet]
    public async Task<IEnumerable<MenuItem>> GetAll()
    {
        return await _menuItemsStore.GetAllAsync();
    }
}
