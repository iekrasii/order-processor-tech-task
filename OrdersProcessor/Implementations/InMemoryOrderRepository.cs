using System.Collections.Concurrent;
using OrdersProcessor.Interfaces;
using OrdersProcessor.Models;

namespace OrdersProcessor.Implementations;

/// <inheritdoc />
public class InMemoryOrderRepository : IOrderRepository
{
    private static readonly ConcurrentDictionary<int, Order> Orders;
    private readonly ILogger _logger;

    static InMemoryOrderRepository()
    {
        Orders = new ConcurrentDictionary<int, Order>();
        Orders.TryAdd(1, new Order { Id = 1, Name = "Laptop" });
        Orders.TryAdd(2, new Order { Id = 2, Name = "Phone" });
    }

    public InMemoryOrderRepository(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public Order GetOrder(int orderId)
    {
        if (orderId <= 0)
            throw new ArgumentException("Order ID must be greater than 0", nameof(orderId));

        if (!Orders.TryGetValue(orderId, out var order))
            throw new KeyNotFoundException($"Order with ID {orderId} not found");

        return order;
    }

    /// <inheritdoc />
    public void AddOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        if (order.Id <= 0)
            throw new ArgumentException("Order ID must be greater than 0", nameof(order));

        if (!Orders.TryAdd(order.Id, order))
            throw new InvalidOperationException($"Order with ID {order.Id} already exists");

        _logger.LogInfo($"Order {order.Id} added successfully");
    }
}