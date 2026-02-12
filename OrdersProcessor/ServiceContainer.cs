using OrdersProcessor.Implementations;
using OrdersProcessor.Interfaces;

/// <summary>
/// The simplest DI container or even more like container emulator as there is no registrations part at all
/// </summary>
public static class ServiceContainer
{
    /// <summary>
    /// Resolves required services
    /// </summary>
    /// <returns></returns>
    public static (IOrderService orderService, ConsoleLogger logger) CreateServices()
    {
        var logger = new ConsoleLogger();
        var repository = new InMemoryOrderRepository(logger);
        var orderService = new OrderService(repository, logger);

        return (orderService, logger);
    }
}