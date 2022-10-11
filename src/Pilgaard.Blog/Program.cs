using MudBlazor.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
var app = ConfigureServices(builder);
await ConfigureRequestPipeline(app).RunAsync();

static WebApplication ConfigureServices(WebApplicationBuilder builder)
{
    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
        builder.Configuration.GetValue<string>("Syncfusion:LicenseKey"));

    builder.Services.AddMudServices();
    builder.Services.AddSignalR().AddAzureSignalR(options =>
    {
        options.ServerStickyMode =
            Microsoft.Azure.SignalR.ServerStickyMode.Required;
    });

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddSyncfusionBlazor();
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

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    return app;
}