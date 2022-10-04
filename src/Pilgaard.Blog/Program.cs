using Azure.Identity;
var builder = WebApplication.CreateBuilder(args);

var app = ConfigureServices(builder);
await ConfigureRequestPipeline(app).RunAsync();

static WebApplication ConfigureServices(WebApplicationBuilder builder)
{
    AddAzureKeyVault(builder);

    if (!builder.Environment.IsDevelopment())
    {
        builder.Services.AddSignalR().AddAzureSignalR(options =>
        {
            options.ServerStickyMode =
                Microsoft.Azure.SignalR.ServerStickyMode.Required;
        });
    }
    else
    {
        builder.Services.AddSignalR();
    }

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    return builder.Build();
}

static void AddAzureKeyVault(WebApplicationBuilder webApplicationBuilder)
{
    var keyVaultEndpoint = Environment.GetEnvironmentVariable("VaultUri");
    ArgumentNullException.ThrowIfNull(keyVaultEndpoint, "Environment.GetEnvironmentVariable(\"VaultUri\")");
    webApplicationBuilder.Configuration.AddAzureKeyVault(new Uri(keyVaultEndpoint), new DefaultAzureCredential());
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