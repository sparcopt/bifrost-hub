using Data.Gateway.Configuration;
using Data.Gateway.OdinEye;
using Data.Gateway.Steam;
using Microsoft.Extensions.Options;
using MudBlazor.Services;
using Serilog;
using Web.Application.Services;
using Websocket.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMudServices();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddLogging();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
        .Enrich.WithProperty("Version", context.Configuration["APP_VERSION"]));

builder.Services
    .AddOptions<OdinEyeOptions>()
    .BindConfiguration(OdinEyeOptions.ConfigSectionPath)
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services
    .AddOptions<SteamOptions>()
    .BindConfiguration(SteamOptions.ConfigSectionPath)
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddSingleton<IOdinEyeWebSocketClient>(provider =>
{
    var logger = provider.GetRequiredService<ILogger<OdinEyeWebSocketClient>>();
    var options = provider.GetRequiredService<IOptions<OdinEyeOptions>>().Value;
    var apiUri = new Uri(options.ApiUrl);
    var webSocketUri = new Uri($"ws://{apiUri.Host}:{apiUri.Port}{options.WebSocketPath}");
    
    var webSocketClient = new WebsocketClient(webSocketUri);
    webSocketClient.Name = "BifrostHubWsClient";
    webSocketClient.ReconnectTimeout = TimeSpan.FromSeconds(options.WebSocketReconnectTimeout);
    webSocketClient.ErrorReconnectTimeout = TimeSpan.FromSeconds(options.WebSocketErrorReconnectTimeout);
    return new OdinEyeWebSocketClient(webSocketClient, logger);
});

builder.Services.AddHttpClient<IOdinEyeApiClient, OdinEyeApiClient>((provider, client) =>
{
    var options = provider.GetRequiredService<IOptions<OdinEyeOptions>>().Value;
    client.BaseAddress = new Uri(options.ApiUrl);
});

builder.Services.AddTransient<SteamAuthenticationHandler>();
builder.Services.AddHttpClient<ISteamApiClient, SteamApiClient>((provider, client) =>
{
    var options = provider.GetRequiredService<IOptions<SteamOptions>>().Value;
    client.BaseAddress = new Uri(options.ApiUrl); 
})
.AddHttpMessageHandler<SteamAuthenticationHandler>();

builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IPlayerService, PlayerService>();
builder.Services.AddSingleton<IServerDetailsService, ServerDetailsService>();
builder.Services.AddSingleton<IGameEventLogger, GameEventLogger>();
builder.Services.AddHostedService<OdinEyeWebSocketService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();