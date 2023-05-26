using Microsoft.Azure.SignalR;
using MudBlazor.Services;
using Pilgaard.Blog.Features.Feed;
using Pilgaard.Blog.Shared;

var builder = WebApplication.CreateBuilder(args);
var app = ConfigureServices(builder);
await ConfigureRequestPipeline(app).RunAsync();

static WebApplication ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddMudServices();
    builder.Services.AddSignalR().AddAzureSignalR(options =>
        options.ServerStickyMode = ServerStickyMode.Required);

    builder.Services.AddScoped<ThemeProvider>();

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    return builder.Build();
}

static WebApplication ConfigureRequestPipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapControllers();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.MapRssFeed();

    return app;
}