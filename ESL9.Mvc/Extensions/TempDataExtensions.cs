using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Mvc.Extensions;

public static class TempDataExtensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        => tempData[key] = JsonSerializer.Serialize(value, _jsonOptions);

    public static T? Get<T>(this ITempDataDictionary tempData, string key) where T : class
    {
        if (tempData.TryGetValue(key, out var obj) && obj is string json && !string.IsNullOrWhiteSpace(json))
        {
            return JsonSerializer.Deserialize<T>(json, _jsonOptions);
        }
        return default;
    }
}
