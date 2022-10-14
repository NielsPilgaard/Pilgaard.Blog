using Pilgaard.Blog.Models;

namespace Pilgaard.Blog.Data;

public static class BlogPosts
{
    public static readonly BlogPostSeries MakingABlog = new("Making a Blog with C#", "making-a-blog", 1, new BlogPost[]
    {
        new("Planning", "1-planning", new DateOnly(2022, 10, 9), 1, "planning"),
        new("Hosting on Azure", "2-hosting",new DateOnly(2022, 10, 9),  2, "hosting", "azure"),
        new("Building the MVP", "3-building-the-mvp", new DateOnly(2022, 10, 9), 3, "prismjs", "seo"),
        new("[WIP] Improving Appearances", "4-improving-appearances", new DateOnly(2022, 10, 14), 4, "mudblazor", "css", "html"),

    }, "blazor");

    public static readonly BlogPostSeries[] AllBlogPostSeries = { MakingABlog };
}