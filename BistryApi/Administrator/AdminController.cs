using BistryApi.Administrator.Requests;
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
}
