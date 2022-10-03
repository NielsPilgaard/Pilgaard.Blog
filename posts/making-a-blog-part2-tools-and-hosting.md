# Making a blog with C# - Part 2 - Tools & Hosting

## Blazor Server or WASM

Blazor is a given, but whether to use Blazor Server or Web Assembly was a hard choice.

I started out with Blazor WASM, but got a bit overwhelmed by all the unknowns, and limitations. 
I usually work with dotnet 6 worker services, so Blazor Server felt like a better fit for me, at least for the time being.

### Hosting

I decided on using Azure for hosting - it feels like the natural choice for dotnet, and I've used it a bit in the past. 

So I created a pay-as-you-go subscription, and a resource group, hoping that'd be enough to get me started.

A little googling had shown me that I'd need to use both Azure App Service and Azure SignalR Services for a Blazor Server app, and that I should be able to provision it through Visual Studio when publishing inititally.
Here's the [documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server?view=aspnetcore-6.0) I found.

The configuration I had to do in Blazor was minimal, I just had to add the following to the startup procedure:

```csharp
builder.Services.AddSignalR().AddAzureSignalR(options =>
{
    options.ServerStickyMode =
        Microsoft.Azure.SignalR.ServerStickyMode.Required;
});
```

However! After adding that, the app could no longer start locally, 
so I wrapped it in an if statement to make sure AzureSignalR isn't used locally:

```csharp
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
```

## Summary

What I ended up with, was the following resources in Azure:

- SignalR Service (Free-tier)
- App Service (Free-tier)
- Cosmos Db (Serverless, almost free)
    - For storing blog posts. Probably overkill, but I wanna try it.
- KeyVault (Almost free)

---

Thanks a lot for reading, I hope to see you in the next post :smiley:



Twitter: [@NillerMedDild](https://twitter.com/NillerMedDild)

GitHub: [NielsPilgaard](https://github.com/NielsPilgaard)