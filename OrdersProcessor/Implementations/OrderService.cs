using OrdersProcessor.Interfaces;

namespace OrdersProcessor.Implementations;

/// <inheritdoc />
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IOrderValidator _validator;
    private readonly ILogger _logger;

    public OrderService(IOrderRepository repository, IOrderValidator validator, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public async Task ProcessOrderAsync(int orderId, CancellationToken ct)
    {
        _logger.LogInfo($"Starting to process order {orderId}");

        try
        {
            if (!_validator.IsValid(orderId))
                throw new InvalidOperationException($"The order {orderId} is not valid for processing");

            _ = _repository.GetOrder(orderId);

            // Emulate processing
            await Task.Delay(100, ct);

            _logger.LogInfo($"Order {orderId} processed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to process order {orderId}", ex);
        }
    }
}