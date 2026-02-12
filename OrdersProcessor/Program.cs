var (orderService, logger) = ServiceContainer.CreateServices();

var cts = new CancellationTokenSource();
var tasks = new[]
{
    orderService.ProcessOrderAsync(1, cts.Token),
    orderService.ProcessOrderAsync(2, cts.Token),
    //orderService.ProcessOrderAsync(-1, cts.Token) // Invalid order
};

await Task.WhenAll(tasks);

logger.LogInfo("All orders processed.");