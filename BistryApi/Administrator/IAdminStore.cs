using BistryApi.Administrator.Requests;
using BistryApi.Orders;

namespace BistryApi.Administrator;

public interface IAdminStore
{
    Task AddMenuItemAsync(AddMenuItemRequest request);

    Task DeleteMenuItemAsync(DeleteMenuItemRequest request);

    Task<IEnumerable<Order>> GetOrdersAsync();

    Task IssueOrderAsync(IssueOrderRequest tableId);
}
