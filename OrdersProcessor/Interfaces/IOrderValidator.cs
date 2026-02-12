namespace OrdersProcessor.Interfaces;

/// <summary>
/// Represents the logic of validating order
/// </summary>
public interface IOrderValidator
{
    /// <summary>
    /// Check if the order is valid
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    bool IsValid(int orderId);
}