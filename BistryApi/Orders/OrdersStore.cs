using BistryApi.Configuration;
using BistryApi.Orders.Requests;
using Microsoft.EntityFrameworkCore;

namespace BistryApi.Orders;

public class OrdersStore : IOrdersStore
{
    private readonly BistryContext _bistryContext;

    public OrdersStore(BistryContext bistryContext)
    {
        _bistryContext = bistryContext;
    }

    public async Task PlaceOrderAsync(PlaceOrderRequest request)
    {
        var order = new Order()
        {
            Id = Guid.NewGuid(),
            TableId = request.TableId,
            MenuItems = request.MenuItems
        };

        _bistryContext.Orders.Add(order);
        await _bistryContext.SaveChangesAsync();
    }

    public async Task CallWaiterAsync(CallWaiterRequest request)
    {
        var callWaiter = new CallWaiter()
        {
            Id = Guid.NewGuid(),
            TableId = request.TableId
        };

        _bistryContext.CallWaiters.Add(callWaiter);
        await _bistryContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CallWaiter>> IsWaiterCalledAsync()
    {
        var calledWaiters = await _bistryContext.CallWaiters.ToListAsync();
        foreach (var calledWaiter in calledWaiters)
        {
            _bistryContext.Attach(calledWaiter);
            _bistryContext.CallWaiters.Remove(calledWaiter);
        }

        await _bistryContext.SaveChangesAsync();
        return calledWaiters;
    }
}
