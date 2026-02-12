using OrdersProcessor.Models;

namespace OrdersProcessor.Interfaces;

/// <summary>
/// Represents the logic of accessing orders
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Gets order by id
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    Order GetOrder(int orderId);

    /// <summary>
    /// Adds new order
    /// </summary>
    /// <param name="order"></param>
    void AddOrder(Order order);
}