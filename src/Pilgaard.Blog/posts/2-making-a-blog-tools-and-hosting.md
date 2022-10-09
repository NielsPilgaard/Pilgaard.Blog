<section id="making-a-blog-part-2">
<h1>Making a blog with C# - Part 2 - Cloud Hosting</h1>
</section>

## Blazor Server or WASM

Blazor is a given, but whether to use Blazor Server or Web Assembly was a hard choice.

I started out with Blazor WASM, but got a bit overwhelmed by all the unknowns, and limitations, and switched to Blazor Server.

I work with dotnet 6 worker services, so Blazor Server felt like the more comfortable choice.

## Hosting

I decided on using Azure for hosting - it feels like the natural choice for dotnet, and I've used it a bit in the past.

So I created a pay-as-you-go subscription, and a resource group, hoping that'd be enough to get me started.

A little googling had shown me that I'd need to use both Azure App Service and Azure SignalR Services for a Blazor Server app, and that I should be able to provision it through Visual Studio when publishing inititally.

Here are the docs I used: https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server?view=aspnetcore-6.0

## Provisioning

### Azure SignalR Service

The first thing I had to do was add a Service Dependency to Azure SignalR Service through Visual Studio:

- Right-clicked on the project and clicked `Publish`
- Clicked the `Connected Services` tab on the left, and then <span style="color:green;font-size:18px">+</span>
- Found `Azure SignalR Service` in the list, and completed the steps to provision it

I started out saving the generated connection string in Azure KeyVault, but I had trouble launching the app locally after that, and switched to using a local `secret.json` file.

### Azure App Service

Next up: Provisioning the App Service that was going to host the Blazor website. I did the following to set that up:

- Right-clicked on the project and clicked `Publish` (again)
- Selected `Azure` as Target and clicked next
- Selected `Azure App Service (Linux)`
- Clicked <span style="color:green;font-size:18px">+</span> Create new
- Completed the steps to provision the `Azure App Service`
  - I configured deployment to be through GitHub actions, so Visual Studio created a workflow yml for me :ok_hand:

When it was created, I went into `Configuration` and added `Azure__SignalR__ConnectionString` as an Application Setting-

I chose Application Setting over Connection string to have it injected as an environment variable. I knew that'd work, and I wasn't sure if adding it as a Connection string would just work out of the box.

# Summary

I decided on using Blazor Server instead of WASM, and Azure for hosting.

What I ended up with was the following resources in Azure:

- SignalR Service (Free-tier)
- App Service (Free-tier)

---

Thanks a lot for reading, I hope to see you in the next post :smiley:

Twitter: [@NillerMedDild](https://twitter.com/NillerMedDild)

GitHub: [NielsPilgaard](https://github.com/NielsPilgaard)
