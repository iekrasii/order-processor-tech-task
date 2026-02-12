namespace OrdersProcessor.Interfaces;

/// <summary>
/// Represents the business logic performed with orders
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Do business processing of the order
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task ProcessOrderAsync(int orderId, CancellationToken ct);
}