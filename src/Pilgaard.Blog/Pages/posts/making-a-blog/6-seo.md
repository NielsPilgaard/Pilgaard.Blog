

> Search engine optimization is the process of improving the quality and quantity of website traffic to a website or a web page from search engines. SEO targets unpaid traffic rather than direct traffic or paid traffic.

```csharp
public static class DefaultMetadata
{
    public const string Title = "Pilgaard | dotnet blog";
    public const string Description = "Hi! I write about code - Particularly C#, but also PowerShell and the occasional JavaScript.";
    public const string Tags = "blazor, dotnet, csharp, blog, programming";
}
```

```csharp
<PageTitle>@Title</PageTitle>
<HeadContent>
    <meta name="description" content="@Description" />
    <meta name="og:title" content="@Title" />
    <meta name="og:description" content="@Description" />

    @if (Tags is not null)
    {
        <meta name="tags" content="@Tags" />
    }
</HeadContent>

@code {
    [Parameter]
    public string Title { get; set; } = null!;

    [Parameter]
    public string Description { get; set; } = null!;

    [Parameter]
    public string? Tags { get; set; } // Comma separated list
}
```

Usage in `Index.razor`
```csharp
<MetadataComponent Title="@DefaultMetadata.Title" Description="@DefaultMetadata.Description" Tags="@DefaultMetadata.Tags" />
```

Usage in `BlogPostComponent.razor`
```csharp
<MetadataComponent 
    Title="@Title" 
    Description="@BlogPost.Description" 
    Tags="@Tags" />

@code {
    private string Title => BlogPostSeries?.Title is null ?
        $"{DefaultMetadata.Title} | {BlogPost.Title}" :
        $"{DefaultMetadata.Title} | {BlogPost.Title} | {BlogPostSeries.Title} - Part {BlogPost.NumberInSeries}";

    private string Tags => string.Join(", ", BlogPost.Tags, BlogPostSeries?.Tags);
}
```
*File trimmed for brevity*
```csharp

```
```csharp

```