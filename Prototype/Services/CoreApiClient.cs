using System.Net.Http.Json;

namespace Prototype.Services;

public interface ICoreApiClient
{
    Task<string?> GetFullNameByEmployeeIdAsync(string employeeId, CancellationToken ct = default);
    Task<string?> GetRoleAsync(string userId, int facilNo, CancellationToken ct = default);
}

internal sealed class CoreApiClient(HttpClient httpClient) : ICoreApiClient
{
    public async Task<string?> GetFullNameByEmployeeIdAsync(string employeeId, CancellationToken ct = default)
        => await httpClient.GetFromJsonAsync<string>($"api/Core/FullNameByID/{Uri.EscapeDataString(employeeId)}", ct);

    public async Task<string?> GetRoleAsync(string userId, int facilNo, CancellationToken ct = default)
        => await httpClient.GetFromJsonAsync<string>($"api/Core/Role/{Uri.EscapeDataString(userId)}/{facilNo}", ct);
}
