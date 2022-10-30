## Blazor Server or WASM
Blazor is a given, but whether to use Blazor Server or Web Assembly was a hard choice.
I started out with Blazor WASM, but got a bit overwhelmed by all the unknowns, and limitations, and switched to Blazor Server.
I work with dotnet 6 worker services, so Blazor Server felt like the more comfortable choice.

## Hosting
I decided on using Azure for hosting - it feels like the natural choice for dotnet, and I've used it a bit in the past.
So I created a pay-as-you-go subscription, and a resource group, hoping that'd be enough to get me started.
A little googling had shown me that I'd need to use both Azure App Service and Azure SignalR Services for a Blazor Server app, and that I should be able to provision it through Visual Studio when publishing inititally.
Here are the docs I used: <a href="https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server?view=aspnetcore-6.0">https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server?view=aspnetcore-6.0</a>

## Provisioning
<hr />

### Azure SignalR Service
The first thing I had to do was add a Service Dependency to Azure SignalR Service through Visual Studio:
<ul>
    <li>Right-clicked on the project and clicked <code>Publish</code></li>
    <li>Clicked the <code>Connected Services</code> tab on the left, and then <span style="color:green;font-size:18px">+</span></li>
    <li>Found <code>Azure SignalR Service</code> in the list, and completed the steps to provision it</li>
</ul>
I started out saving the generated connection string in Azure KeyVault, but I had trouble launching the app locally after that, and switched to using a local <code>secret.json</code> file.

### Azure App Service

Next up: Provisioning the App Service that was going to host the Blazor website. I did the following to set that up:
<ul>
    <li>Right-clicked on the project and clicked <code>Publish</code> (again)</li>
    <li>Selected <code>Azure</code> as target and clicked next</li>
    <li>Selected <code>Azure App Service (Linux)</code></li>
    <li>Clicked <span style="color:green;font-size:18px">+</span> Create new</li>
    <li>
        Completed the steps to provision the <code>Azure App Service</code>
        <ul>
            <li>I configured deployment to be through GitHub actions, so Visual Studio created a workflow yml for me 👌</li>
        </ul>
    </li>
</ul>

When it was created, I went into <code>Configuration</code> and added <code>Azure__SignalR__ConnectionString</code> as an Application Setting-
I chose Application Setting over Connection string to have it injected as an environment variable. I knew that'd work, and I wasn't sure if adding it as a Connection string would just work out of the box.

## Summary

I decided on using Blazor Server instead of WASM, and Azure for hosting.
What I ended up with was the following resources in Azure:
<ul>
    <li>SignalR Service (Free-tier)</li>
    <li>App Service (Free-tier)</li>
</ul>