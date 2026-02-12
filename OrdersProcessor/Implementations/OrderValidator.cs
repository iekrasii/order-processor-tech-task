using OrdersProcessor.Interfaces;

namespace OrdersProcessor.Implementations;

/// <inheritdoc />
public class OrderValidator : IOrderValidator
{
    private readonly IOrderRepository _repository;

    public OrderValidator(IOrderRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public bool IsValid(int orderId)
    {
        var order = _repository.GetOrder(orderId);
        return order.IsValid;
    }
}