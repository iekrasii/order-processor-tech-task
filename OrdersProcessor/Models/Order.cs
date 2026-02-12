namespace OrdersProcessor.Models;

public class Order
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}