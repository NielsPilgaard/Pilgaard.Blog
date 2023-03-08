I wanted to make links to my blog posts more accurate, so I needed to add some `<meta>` tags 
to provide title, description and tags to the websites displaying links. 

I wanted to use the data I already have for rendering blog post cards on the front page, so I figured I'd make a component for it:
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

This uses the built-in `<PageTitle>` and `<HeadContent>` Component to update title and metadata respectively.

The meta tags that start in `og` helps sites like Twitter and Facebook display the information in a nice way.

To make use of the new `MetadataComponent`, I first removed the title and meta tags from `Index.razor`,
and replaced it with this:


Usage in `Index.razor`
```csharp
<MetadataComponent Title="@DefaultMetadata.Title" Description="@DefaultMetadata.Description" Tags="@DefaultMetadata.Tags" />
```
The defaults are defined in a separate file:
```csharp
public static class DefaultMetadata
{
    public const string Title = "Pilgaard | dotnet blog";
    public const string Description = "Hi! I write about code - Particularly C#, but also PowerShell and the occasional JavaScript.";
    public const string Tags = "blazor, dotnet, csharp, blog, programming";
}
```

To set it up for BlogPosts, I did the following in `BlogPostComponent.razor`:

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

## Summary

We've seen that adding SEO metadata to Blazor Server is a breeze using the built in `<PageTitle>` and `<HeadContent` components.