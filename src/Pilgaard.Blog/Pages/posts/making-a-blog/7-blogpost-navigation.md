Currently navigating between posts is cumbersome, so I wanted to add easy navigation.

To do this, I made a `BlogPostNavigation` component and added it to my `BlogPostComponent`.

All my blog posts are currently stored in-code, so it's luckily very easy to determine whether there's a next/previous post in the series:

`BlogPostNavigation.razor`:
```csharp
<div class="mt-5">
<BlogPostNavigationButton BlogPost="_previousBlogPost"
                          BlogPostSeries="BlogPostSeries"
                          Next="false" />

<BlogPostNavigationButton BlogPost="_nextBlogPost"
                          BlogPostSeries="BlogPostSeries"
                          Next="true" />
</div>
@code {
    [Parameter]
    public BlogPostSeries BlogPostSeries { get; set; } = null!;

    [Parameter]
    public BlogPost CurrentBlogPost { get; set; } = null!;

    BlogPost? _previousBlogPost;
    BlogPost? _nextBlogPost;

    protected override void OnInitialized()
    {
        if (CurrentBlogPost.NumberInSeries > 1)
        {
            _previousBlogPost = BlogPostSeries
                .BlogPosts
                .FirstOrDefault(bp => bp.NumberInSeries == CurrentBlogPost.NumberInSeries - 1);
        }

        _nextBlogPost = BlogPostSeries
            .BlogPosts
            .FirstOrDefault(bp => bp.NumberInSeries == CurrentBlogPost.NumberInSeries + 1);
    }
}
```

The next and previous blog posts are determined based on the current blog post's number in it's series +/-1

They're then passed to the `BlogPostNavigationButton` component which renders them nicely, or returns early if they're null.

`BlogPostNavigationButton.razor`:
```csharp
@inject NavigationManager NavigationManager

@if (BlogPost is null)
{
    return;
}

<MudButton Color="Color.Primary"
           OnClick="@NavigateToBlogPost"
           Variant="Variant.Filled"
           StartIcon="@(Next ? string.Empty : Icons.Material.Filled.NavigateBefore)"
           EndIcon="@(Next ? Icons.Material.Filled.NavigateNext : string.Empty)"
           Size="Size.Small">
    @(Next ? $"Next: {BlogPost.Title}" : $"Previous: {BlogPost.Title}")
</MudButton>

@code {
    [Parameter] 
    public BlogPost? BlogPost { get; set; } = null!;
    
    [Parameter] 
    public BlogPostSeries BlogPostSeries { get; set; } = null!;
    
    [Parameter] 
    public bool Next { get; set; }

    private void NavigateToBlogPost() 
        => NavigationManager.NavigateTo(
            uri: BlogPostSeries.GetRelativePath(BlogPost!), 
            forceLoad: true);
}
```

The BlogPostNavigationButton handles navigating to the previous/next blog post using the built-in `NavigationManager`. 
It's important to set `forceLoad` to true, because otherwise the markdown isn't reconstructed correctly.

Tying it all together in `BlogPostComponent.razor`:
```csharp
<BlogPostNavigation CurrentBlogPost="BlogPost" BlogPostSeries="BlogPostSeries"/>
```

And that's it!

Here's what the end product looks like:

![Blogpost Navigation](https://user-images.githubusercontent.com/21295394/224116593-55383715-a8ff-4c93-929e-e9491e06509a.png)

## Summary

We've added simple navigation buttons to move between blog posts, to make for a nicer experience.

### See the code 

https://github.com/NielsPilgaard/Pilgaard.Blog/pull/23

### The state of the blog
![State of the blog](https://user-images.githubusercontent.com/21295394/224152139-cd53b1a6-a89f-4b85-b10a-4beae4b83a22.png)

