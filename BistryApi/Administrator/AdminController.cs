using BistryApi.Administrator.Requests;
using BistryApi.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistryApi.Administrator;

[ApiController]
[Route("[controller]")]
[Authorize(Policy = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminStore _adminStore;

    public AdminController(IAdminStore adminStore)
    {
        _adminStore = adminStore;
    }

    [HttpPost]
    [Route("AddMenuItem")]
    public async Task AddMenuItem([FromBody] AddMenuItemRequest request)
    {
        await _adminStore.AddMenuItemAsync(request);
    }

    [HttpDelete]
    [Route("DeleteMenuItem/{Id}")]
    public async Task DeleteMenuItem([FromRoute] DeleteMenuItemRequest request)
    {
        await _adminStore.DeleteMenuItemAsync(request);
    }

    [HttpGet]
    [Route("GetOrders")]
    public async Task<IEnumerable<Order>> GetOrders()
    {
        return await _adminStore.GetOrdersAsync();
    }

    [HttpPost]
    [Route("IssueOrder")]
    public async Task IssueOrder([FromBody] IssueOrderRequest request)
    {
        await _adminStore.IssueOrderAsync(request);
    }
}
