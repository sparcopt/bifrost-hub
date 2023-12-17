namespace Data.Gateway.Steam;

using Configuration;
using Microsoft.Extensions.Options;

public class SteamAuthenticationHandler : DelegatingHandler
{
    private readonly SteamOptions steamOptions;
    private const string KeyParameter = "key";
    
    public SteamAuthenticationHandler(IOptions<SteamOptions> options)
    {
        steamOptions = options.Value;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var uriBuilder = new UriBuilder(request.RequestUri);
        uriBuilder.Query = string.IsNullOrEmpty(uriBuilder.Query)
            ? $"{KeyParameter}={steamOptions.ApiKey}"
            : $"{uriBuilder.Query}&{KeyParameter}={steamOptions.ApiKey}";
        
        request.RequestUri = uriBuilder.Uri;
        return base.SendAsync(request, cancellationToken);
    }
}