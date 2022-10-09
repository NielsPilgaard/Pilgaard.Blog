<section id="making-a-blog-part-3">
<h1>Making a blog with C# - Part 3 - Building the MVP</h1>
</section>

The first couple of blog posts are simply `.md` files stored in my project.
In order to actually display them on the website, here's what I did:

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



## Rendering Markdown with Markdig

### Prettier Code Blocks

### Syntax Highlighting

### Page Links missbehaving

## Going Live

---

Thanks a lot for reading, I hope to see you in the next post :smiley:

Twitter: [@NillerMedDild](https://twitter.com/NillerMedDild)

GitHub: [NielsPilgaard](https://github.com/NielsPilgaard)
