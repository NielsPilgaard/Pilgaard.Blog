[MudBlazor 6.2.0](https://github.com/MudBlazor/MudBlazor/releases/tag/v6.2.0) allows watching for changes in the dark/light theme preference. I think that's pretty cool, so I want it on my blog :smile:

It requires minimal changes, since the blog already uses `ThemeProvider` to determine dark/light theme. 

I made a new razor component to hold all the theming logic:

```cshtml
<MudThemeProvider @ref="@_mudThemeProvider" @bind-IsDarkMode="@_isDarkMode" Theme="CustomTheme" />

@code {
    // set this to true if you expect most of your users to use dark mode, otherwise false
    // this controls the initial theme while loading user preference, 
    // if set to false it can be a bit jarring and cause a white out.
    private bool _isDarkMode = true;

    private MudThemeProvider _mudThemeProvider = new();

    static readonly MudTheme CustomTheme = new()
        {
            // trimmed for brevity
        };

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _isDarkMode = await _mudThemeProvider.GetSystemPreference();

            await _mudThemeProvider.WatchSystemPreference(OnSystemPreferenceChanged);

            StateHasChanged();
        }
    }

    private Task OnSystemPreferenceChanged(bool newValue)
    {
        _isDarkMode = newValue;

        StateHasChanged();

        return Task.CompletedTask;
    }
}
```

I set the initial value of `_darkMode` to `true` because I'm guessing that most people reading my blog use dark mode.

If set to false it can be a bit jarring and cause a white out.

### Keeping the state

In order to remember system preference between page loads, it's a good idea to add the ThemeProvider to dependency injection as a scoped service:

`builder.Services.AddScoped<ThemeProvider>();`

That will ensure the system preference is kept in-memory for each user, on page loads after the first.

### Finishing up

In order to use the `ThemeProvider`, simply plop it in `MainLayout.razor`. 

Here's what mine looks like after these changes:

```cshtml
@inherits LayoutComponentBase

<ThemeProvider/>
<MudDialogProvider />
<MudSnackbarProvider />

<MudLayout>
    <AppBar />
    <MudMainContent>
        <MudContainer MaxWidth="MaxWidth.Large" Class="my-4 pt-4">
            @Body
        </MudContainer>
    </MudMainContent>
</MudLayout>
```

## Summary

We learned how to use MudBlazor to keep dark/light mode settings in sync with system preference. 

Thank you [TDroogers](https://github.com/TDroogers) for [adding this feature to MudBlazor](https://github.com/MudBlazor/MudBlazor/pull/6320)!

### See the code

[Pull Request implementing the changes in this post](https://github.com/NielsPilgaard/Pilgaard.Blog/pull/23)

### The state of the blog

![State of the blog](https://user-images.githubusercontent.com/21295394/224152139-cd53b1a6-a89f-4b85-b10a-4beae4b83a22.png)
