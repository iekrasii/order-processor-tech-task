using OrdersProcessor.Implementations;
using OrdersProcessor.Interfaces;
using OrdersProcessor.Models;
using Moq;

namespace OrdersProcessor.Tests;

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _mockRepository;
    private readonly Mock<IOrderValidator> _mockValidator;
    private readonly Mock<ILogger> _mockLogger;
    private readonly OrderService _orderService;

    public OrderServiceTests()
    {
        _mockRepository = new Mock<IOrderRepository>();
        _mockValidator = new Mock<IOrderValidator>();
        _mockLogger = new Mock<ILogger>();
        _orderService = new OrderService(_mockRepository.Object, _mockValidator.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task ProcessOrderAsync_OrderIsValid_ProcessedSuccessfully()
    {
        // Arrange
        int orderId = 1;
        var order = new Order { Id = orderId, Name = "Test Product" };
        _mockValidator.Setup(v => v.IsValid(orderId)).Returns(true);
        _mockRepository.Setup(r => r.GetOrder(orderId)).Returns(order);

        // Act
        await _orderService.ProcessOrderAsync(orderId, CancellationToken.None);

        // Assert
        _mockLogger.Verify(l => l.LogInfo($"Starting to process order {orderId}"), Times.Once);
        _mockValidator.Verify(v => v.IsValid(orderId), Times.Once);
        _mockRepository.Verify(r => r.GetOrder(orderId), Times.Once);
        _mockLogger.Verify(l => l.LogInfo($"Order {orderId} processed successfully"), Times.Once);
        _mockLogger.Verify(l => l.LogError(It.IsAny<string>(), It.IsAny<Exception>()), Times.Never);
    }

    [Fact]
    public async Task ProcessOrderAsync_OrderIsInvalid_AppropriateErrorLogged()
    {
        // Arrange
        int orderId = 1;
        _mockValidator.Setup(v => v.IsValid(orderId)).Returns(false);

        // Act
        await _orderService.ProcessOrderAsync(orderId, CancellationToken.None);

        // Assert
        _mockLogger.Verify(l => l.LogInfo($"Starting to process order {orderId}"), Times.Once);
        _mockValidator.Verify(v => v.IsValid(orderId), Times.Once);
        _mockRepository.Verify(r => r.GetOrder(It.IsAny<int>()), Times.Never);
        _mockLogger.Verify(l => l.LogError(
            $"Failed to process order {orderId}",
            It.IsAny<InvalidOperationException>()), Times.Once);
        _mockLogger.Verify(l => l.LogInfo($"Order {orderId} processed successfully"), Times.Never);
    }
}
