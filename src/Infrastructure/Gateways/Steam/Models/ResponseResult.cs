namespace BifrostHub.Infrastructure.Gateways.Steam.Models;

using System.Text.Json.Serialization;

public class Response<T>
{
    [JsonPropertyName("response")]
    public T Data { get; set; }
}

public class PlayerSummaryResponse
{
    public IEnumerable<PlayerSummary> Players { get; set; }
}