using OrdersProcessor.Implementations;
using OrdersProcessor.Interfaces;
using Moq;

namespace OrdersProcessor.Tests;

public class InMemoryOrderRepositoryTests
{
    private readonly InMemoryOrderRepository _repository;

    public InMemoryOrderRepositoryTests()
    {
        var mockLogger = new Mock<ILogger>();
        _repository = new InMemoryOrderRepository(mockLogger.Object);
    }

    [Fact]
    public void GetOrder_OrderExists_ReturnsOrder()
    {
        // Arrange
        int orderId = 1;

        // Act
        var result = _repository.GetOrder(orderId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(orderId, result.Id);
        Assert.Equal("Laptop", result.Name);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GetOrder_InvalidId_ThrowsArgumentException(int invalidId)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _repository.GetOrder(invalidId));
        Assert.Equal("orderId", exception.ParamName);
        Assert.Contains("Order ID must be greater than 0", exception.Message);
    }

    [Fact]
    public void GetOrder_OrderDoesNotExist_ThrowsKeyNotFoundException()
    {
        // Arrange
        int nonExistentId = 999;

        // Act & Assert
        var exception = Assert.Throws<KeyNotFoundException>(() => _repository.GetOrder(nonExistentId));
        Assert.Contains($"Order with ID {nonExistentId} not found", exception.Message);
    }
}