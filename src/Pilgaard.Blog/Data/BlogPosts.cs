using Pilgaard.Blog.Models;

namespace Pilgaard.Blog.Data;

public static class BlogPosts
{
    public static readonly BlogPostSeries MakingABlog = new(
        title: "Making a Blog with C#",
        description: "In this series, we build *this* website from scratch, using NET6.0 and blazor",
        pathName: "making-a-blog",
        order: 1,
        blogPosts: new BlogPost[]
        {
            new(title: "Planning",
                description: "In this post, we layout the plan for making a blog.",
                pathName: "1-planning",
                publishDate: new DateOnly(year: 2022, month: 10, day: 9),
                numberInSeries: 1,
                "planning"),
            new(title: "Hosting on Azure",
                description: "In this post, we look at how to host Blazor Server, and where to host it.",
                pathName: "2-hosting",
                publishDate: new DateOnly(year: 2022, month: 10, day: 9),
                numberInSeries: 2,
                "hosting", "azure"),
            new(title: "Building the MVP",
                description: "In this post, we build the blog MVP, and go live!",
                pathName: "3-building-the-mvp",
                publishDate: new DateOnly(year: 2022, month: 10, day: 9),
                numberInSeries: 3,
                "prismjs",
                "seo"),
            new(title: "Improving Appearances",
                description: "In this post, we make the blog nicer to look at. I hope.",
                pathName: "4-improving-appearances",
                publishDate: new DateOnly(year: 2022, month: 10, day: 19),
                numberInSeries: 4,
                "mudblazor",
                "css",
                "html"),
            new(title: "Adding Comments",
                description: "In this post, we add a comment section to each blog post.",
                pathName: "5-adding-comments",
                publishDate: new DateOnly(year: 2022,
                    month: 10,
                    day: 22),
                numberInSeries: 5,
                "giscus",
                "github"),
            //new(title: "SEO",
            //    description: "In this post, we add Search Engine Optimizations to make the blog easier to find.",
            //    pathName: "6-seo",
            //    publishDate: new DateOnly(year: 2022,
            //        month: 10,
            //        day: 22),
            //    numberInSeries: 6,
            //    "seo"),
            //new (title: "",
            //    description: "",
            //    pathName: "",
            //    publishDate: new DateOnly(2022,
            //        10,
            //        22),
            //    numberInSeries: 6,
            //    ""),
        }, "blazor", "dotnet");

    public static readonly BlogPostSeries[] AllBlogPostSeries = { MakingABlog };
}