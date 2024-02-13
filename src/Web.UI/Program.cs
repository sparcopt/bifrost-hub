using BifrostHub.Application.Extensions;
using BifrostHub.Infrastructure.Extensions;
using Hangfire;
using MudBlazor.Services;
using Oakton;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddMudServices()
    .AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Host.AddInfraDependencies(typeof(Program));
builder.Services
    .AddInfraDependencies()
    .AddApplicationDependencies();

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
app.UseHangfireDashboard();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Required to parse Wolverine code generation commands
return await app.RunOaktonCommands(args);