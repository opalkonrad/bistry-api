using BistryApi.Orders.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BistryApi.Orders;

[Route("[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrdersStore _ordersStore;

    public OrdersController(IOrdersStore ordersStore)
    {
        _ordersStore = ordersStore;
    }

    [HttpPost]
    [Route("PlaceOrder")]
    public async Task PlaceOrder([FromBody] PlaceOrderRequest request)
    {
        await _ordersStore.PlaceOrderAsync(request);
    }

    [HttpGet]
    [Route("CallWaiter")]
    public async Task CallWaiter([FromRoute] CallWaiterRequest request)
    {
        await _ordersStore.CallWaiterAsync(request);
    }

    [HttpGet]
    [Route("IsWaiterCalled")]
    public async Task<IEnumerable<CallWaiter>> IsWaiterCalled()
    {
        return await _ordersStore.IsWaiterCalledAsync();
    }
}
