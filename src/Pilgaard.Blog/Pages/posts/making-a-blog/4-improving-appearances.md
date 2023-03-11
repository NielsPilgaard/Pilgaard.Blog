## Razor vs Markdown

After experimenting with MudBlazor I made the decision to use `.razor` files for blog posts instead of markdown.
Using markdown is super convenient, but Blazor Components can do so much more.

Plus, by using Blazor Components for blog posts I'll be able to showcase Blazor
features more easily, should I choose to do so in the future.

So I went ahead and converted my `.md` files to HTML using
<a target="_blank" href="https://markdowntohtml.com/">this online tool</a>.
It looked awful at first, and colored code blocks were a complete mess.

Then I changed all `p` tags to `MudText`, leveraging the default styling of MudBlazor.

In order to un-break code blocks, I figured out I could use string literals
and then convert them with my old markdown to HTML processor. It had to be string literals, because otherwise
HTML wouldn't be shown correctly "as code":

### Code

````csharp
@(@"
```html
<a href="#item-id-here"></a>
```
".ToHtml())
````

### Output

```html
<a href="#item-id-here"></a>
```

## MudBlazor

I wanted to try out a Blazor Component library to improve my chances of making a nice looking blog.

My first choice was actually <a href="https://www.syncfusion.com/blazor-components" target="_blank">SyncFusion</a> - I was curious after watching some of <a target="_blank" href="https://www.youtube.com/user/IAmTimCorey">Tim Corey</a>'s videos about it.
I got a personal license for SyncFusion, and set it up.

Then I started looking at the docs on how to use it, and got flashbacks to my days of styling ASP.NET Core 2.1 MVC with JavaScript 😬

I didn't particularly enjoy those days to be honest, so I had a look at the <a target="_blank" href="https://mudblazor.com/docs/overview">MudBlazor docs</a> instead. It looked much more appealing to me.

I added it to my Blazor project by simply following the steps in the <a target="_blank" href="https://mudblazor.com/getting-started/installation">MudBlazor Getting Started guide</a>.

## Dark Mode

I wanted to either offer a dark mode toggle, or change the color scheme to something darker.

Luckily making and changing between light/dark mode is very simple with MudBlazor, and there's even a <a target="_blank" href="https://mudblazor.com/customization/overview#dark-palette">guide</a> for it.

It's possible to change mode depending on the system preference of the user:

```csharp
<MudThemeProvider @ref="@_mudThemeProvider" @bind-IsDarkMode="@_isDarkMode" />
@code {
    private bool _isDarkMode;
    private MudThemeProvider _mudThemeProvider;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _isDarkMode = await _mudThemeProvider.GetSystemPreference();
            StateHasChanged();
        }
    }
}
```

## Social Media Links

As it turns out, making good looking links to Social Media websites is really easy with MudBlazor:

```csharp
<MudIconButton Icon="@Icons.Custom.Brands.LinkedIn" Color="Color.Inherit" Link="https://www.linkedin.com/in/niels-pilgaard/" Title="My LinkedIn Profile" target="_blank" />
<MudIconButton Icon="@Icons.Custom.Brands.Twitter" Color="Color.Inherit" Link="https://twitter.com/Niels_Pilgaard" Title="My Twitter Profile" target="_blank" />
<MudIconButton Icon="@Icons.Custom.Brands.GitHub" Color="Color.Inherit" Link="https://github.com/NielsPilgaard" Title="My GitHub Profile" target="_blank" />
```

## Summary

I've managed to make the website look better, in my opinion.

I think this has been a good first round of UI improvements :D

### See the code

[Pull Request implementing the changes in this post](https://github.com/NielsPilgaard/Pilgaard.Blog/pull/2)

### The state of the blog

![State of the blog](https://user-images.githubusercontent.com/21295394/224504771-ee180e6f-18be-4ff9-b86a-614d117ee937.png)
