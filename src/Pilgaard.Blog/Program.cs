using MudBlazor.Services;
using Pilgaard.Blog;
using Pilgaard.Blog.Features.Feed;
using Pilgaard.Blog.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();

builder.Services.AddScoped<ThemeProvider>();

builder.Services.AddRazorComponents();

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

app.MapRazorComponents<App>();

app.MapRssFeed();

await app.RunAsync();
