<h1 id="making-a-blog-part-3">Making a blog with C# - Part 3 - Building the MVP</h1>

The first couple of blog posts are simply `.md` files stored in my project.
In order to actually display them on the website, I added the code below to `Index.razor`:

```csharp
@page "/"
@using Pilgaard.Blog.Extensions

@foreach (var blogPost in _blogPosts)
{
    @blogPost
}

@code {
    private readonly List<MarkupString> _blogPosts = new();
    protected override async Task OnInitializedAsync()
    {
        var postsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Posts");
        var fileNames = Directory.EnumerateFiles(postsPath, "*.md", SearchOption.TopDirectoryOnly);
        foreach (var fileName in fileNames)
        {
            var text = await File.ReadAllTextAsync(fileName);
            _blogPosts.Add(text.ToHtml());
        }
    }
}
```

This does the following:

- Find all `.md` files that should be displayed
  - With this approach, files must be copied to the output directory on build
- Read the files
- Convert their text to HTML
- Render the HTML

<hr/>

## Rendering Markdown with Markdig

I used [Markdig](https://github.com/xoofx/markdig) to convert markdown to HTML, through an extension method:

```csharp
public static class StringExtensions
{
    public static readonly MarkdownPipeline MarkdownPipeline =
        new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseEmojiAndSmiley()
            .Build();

    public static MarkupString ToHtml(this string text)
    {
        var htmlText = Markdown.ToHtml(text, MarkdownPipeline);
        return new MarkupString(htmlText);
    }
}
```

<hr/>

## Syntax Highlighted Code Blocks

I started out using the Markdig extension [Markdig.SyntaxHighlighting](https://github.com/arthurrump/MarkdigExtensions) to add color to code blocks, but I thought the colors were a bit dull, so I switched it out with [PrismJs](https://prismjs.com/).

To get Prism to colorize code blocks, here's what to do:

1. Customize and download Prism from https://prismjs.com/download.html
2. Put the `prism.js` and `prism.css` files in the `wwwroot` folder of the project.
3. Add links to the files in the `_Layout.cshtml`:

```cshtml
<head>
  ...
  <link href="css/prism.css" rel="stylesheet" />
</head>

<body>
  ...
  <script src="scripts/prism.js"></script>
</body>
```

4. Add this function to the page that should be highlighted:

```razor
// This should be at the top
@inject IJSRuntime JsRuntime
@code {
protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JsRuntime.InvokeVoidAsync("window.Prism.highlightAll");
        await base.OnAfterRenderAsync(firstRender);
    }
}

```

And that's it!

<hr/>

## Page Links missbehaving

I wanted to add a little section at the top with links to each part of this blog series, but I just couldn't get page links like this one to work:

```html
<a href="#item-id-here"></a>
```

After an intense googling session, I stumpled upon this issue:
https://github.com/dotnet/aspnetcore/issues/8393

Apparently, this type of link just doesn't work in Blazor yet. Huh.

Luckily, there's a workaround that works just fine for my use-case:
Adding `onclick="event.stopPropagation();"`

```html
<a href="#item-id-here" onclick="event.stopPropagation();"></a>
```

The caveat is that this will stop any other `onclick` EventHandler from firing for that specific element, but I can live with that.

Credit to [SQL-MisterMagoo](https://github.com/dotnet/aspnetcore/issues/8393#issuecomment-526545768) for the workaround :D

<hr/>

## Accidental SEO

While adding Prism to `_Layout.cstml`, I couldn't help myself and added some meta tags while I was in there:

```html
<meta
  name="description"
  content="Hi! I write about code - Particularly C#, but also the occasional PowerShell and JavaScript."
/>
<meta property="og:url" content="https://pilgaard-blog.azurewebsites.net/" />
<meta property="og:type" content="website" />
<meta property="og:title" content="Pilgaard | dotnet blog" />
<meta
  property="og:description"
  content="Hi! I write about code - Particularly C#, but also the occasional PowerShell and JavaScript."
/>
<meta
  property="og:image"
  content="https://pilgaard-blog.azurewebsites.net/favicon.ico"
/>
```

That should make links to the blog render nicely on Twitter, and Facebook.

<br/>

# Going Live

And with that, the website MVP was ready to go live! At this point, I announced the website and my plans on Twitter:

---

Thanks a lot for reading, I hope to see you in the next post :smiley:

Twitter: [@NillerMedDild](https://twitter.com/NillerMedDild)

GitHub: [NielsPilgaard](https://github.com/NielsPilgaard)
