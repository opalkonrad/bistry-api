namespace BistryApi.MenuItems;

public interface IMenuItemsStore
{
    public Task<IEnumerable<MenuItem>> GetAllAsync();
}
