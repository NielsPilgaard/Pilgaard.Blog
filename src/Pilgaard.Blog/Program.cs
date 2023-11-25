using Microsoft.Azure.SignalR;
using MudBlazor.Services;
using Pilgaard.Blog;
using Pilgaard.Blog.Features.Feed;
using Pilgaard.Blog.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();
builder.Services.AddSignalR().AddAzureSignalR(options =>
    options.ServerStickyMode = ServerStickyMode.Required);

builder.Services.AddScoped<ThemeProvider>();

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapRssFeed();

await app.RunAsync();
