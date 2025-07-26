using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// using GateSimSharp.Hubs; // Removed because 'Hubs' namespace does not exist

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages and Blazor Server services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
// app.MapHub<SensorHub>("/sensorhub"); // Removed because 'SensorHub' does not exist
app.MapFallbackToPage("/_Host");

app.Run();
