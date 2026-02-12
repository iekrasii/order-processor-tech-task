using OrdersProcessor.Implementations;
using OrdersProcessor.Interfaces;
using Microsoft.Extensions.Configuration;

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
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var logger = new ConsoleLogger(configuration);
        var repository = new InMemoryOrderRepository(logger);
        var orderValidator = new OrderValidator(repository);
        var orderService = new OrderService(repository, orderValidator, logger);

        return (orderService, logger);
    }
}