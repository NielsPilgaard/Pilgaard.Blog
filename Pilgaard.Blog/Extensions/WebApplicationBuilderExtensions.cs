using Pilgaard.Blog.Data;

namespace Pilgaard.Blog.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder, string[] args)
    {
        builder.Services.AddSignalR().AddAzureSignalR(options =>
        {
            options.ServerStickyMode =
                Microsoft.Azure.SignalR.ServerStickyMode.Required;
        });

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();

        return builder.Build();
    }
}