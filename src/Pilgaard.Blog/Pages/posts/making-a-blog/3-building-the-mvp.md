### Making a blog with C# - Part 3
# Building the MVP
<hr />

The first couple of blog posts are simply <code>.md</code> files stored in my project.

In order to actually display them on the website, I added the code below to <code>Index.razor</code>:

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
        var fileNames = Directory.EnumerateFiles(postsPath, " *.md", SearchOption.TopDirectoryOnly);
        foreach (var fileName in fileNames)
        {
            var text = await File.ReadAllTextAsync(fileName);
            _blogPosts.Add(text.ToHtml());
        }
    }
}
```

This does the following:
<ul>
    <li>
        Find all <code>.md</code> files that should be displayed
        <ul>
            <li>With this approach, files must be copied to the output directory on build</li>
        </ul>
    </li>
    <li>Read the files</li>
    <li>Convert their text to HTML</li>
    <li>Render the HTML</li>
</ul>
##Rendering Markdown with Markdig
I used <a href="https://github.com/xoofx/markdig">Markdig</a> to convert markdown to HTML, through an extension method:


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


## Syntax Highlighted Code Blocks
I started out using the Markdig extension <a href="https://github.com/arthurrump/MarkdigExtensions">Markdig.SyntaxHighlighting</a> to add color to code blocks, but I thought the colors were a bit dull, so I switched it out with <a href="https://prismjs.com/">PrismJs</a>.
To get Prism to colorize code blocks, here's what to do:
<ul>
    <li>Customize and download Prism from <a href="https://prismjs.com/download.html">https://prismjs.com/download.html</a></li>
    <li>Put the <code>prism.js</code> and <code>prism.css</code> files in the <code>wwwroot</code> folder of the project.</li>
    <li>Add links to the files in the <code>_Layout.cshtml</code>:</li>
</ul>

```html
<head>
...
<link href="css/prism.css" rel="stylesheet" />
</head>

<body>
...
<script src="scripts/prism.js"></script>
</body>
```
    
<ul>
    <li>Add this function to the page that should be highlighted:</li>
</ul>

```csharp
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

## Page Links misbehaving
I wanted to add a little section at the top with links to each part of this blog series, but I just couldn't get page links like this one to work:


```html
<a href="#item-id-here"></a>
```


After an intense googling session, I stumpled upon this issue:
<a href="https://github.com/dotnet/aspnetcore/issues/8393">https://github.com/dotnet/aspnetcore/issues/8393</a>

Apparently, this type of link just doesn't work in Blazor yet. Huh.

Luckily, there's a workaround that works just fine for my use-case:
Adding <code>onclick="event.stopPropagation();"</code>


```html
<a href="#item-id-here" onclick="event.stopPropagation();"></a>
```

The caveat is that this will stop any other <code>onclick</code> EventHandler from firing for that specific element, but I can live with that.
Credit to <a href="https://github.com/dotnet/aspnetcore/issues/8393#issuecomment-526545768">SQL-MisterMagoo</a> for the workaround :D

## Accidental SEO
While adding Prism to <code>_Layout.cstml</code>, I couldn't help myself and added some meta tags while I was in there:


```html
<meta name="description"
      content="Hi! I write about code - Particularly C#, but also the occasional PowerShell and JavaScript." />
<meta property="og:url" content="https://pilgaard-blog.azurewebsites.net/" />
<meta property="og:type" content="website" />
<meta property="og:title" content="Pilgaard | dotnet blog" />
<meta property="og:description"
      content="Hi! I write about code - Particularly C#, but also the occasional PowerShell and JavaScript." />
<meta property="og:image"
      content="https://pilgaard-blog.azurewebsites.net/favicon.ico" />
```

That should make links to the blog render nicely on Twitter, and Facebook.

## Going Live
And with that, the website MVP was ready to go live! At this point, I announced the website and my plans on Twitter: <a href="https://twitter.com/NillerMedDild/status/1579210443687890946">https://twitter.com/NillerMedDild/status/1579210443687890946</a>
