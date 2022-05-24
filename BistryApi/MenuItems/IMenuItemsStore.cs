namespace BistryApi.MenuItems;

public interface IMenuItemsStore
{
    Task<IEnumerable<MenuItem>> GetAllAsync();
}
