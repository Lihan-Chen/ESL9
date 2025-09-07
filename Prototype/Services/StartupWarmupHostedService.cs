namespace Prototype.Services;

internal sealed class StartupWarmupHostedService(
    ILogger<StartupWarmupHostedService> logger,
    ICoreApiClient coreApiClient) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            // Example warm-up call(s)
            _ = await coreApiClient.GetFullNameByEmployeeIdAsync("U01234", cancellationToken);
            logger.LogInformation("Core API warm-up completed.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Core API warm-up failed (continuing).");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
