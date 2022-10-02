namespace Pilgaard.Blog.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder, string[] args)
    {
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
}