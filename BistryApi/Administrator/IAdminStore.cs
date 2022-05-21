using BistryApi.Administrator.Requests;

namespace BistryApi.Administrator;

public interface IAdminStore
{
    Task AddMenuItemAsync(AddMenuItemRequest request);

    Task DeleteMenuItemAsync(DeleteMenuItemRequest request);
}
