using BistryApi.Orders.Requests;

namespace BistryApi.Orders;

public interface IOrdersStore
{
    Task PlaceOrderAsync(PlaceOrderRequest request);

    Task CallWaiterAsync(CallWaiterRequest request);

    Task<IEnumerable<CallWaiter>> IsWaiterCalledAsync();
}
