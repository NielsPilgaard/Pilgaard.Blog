﻿using Pilgaard.Blog.Features.Feed;

namespace Pilgaard.Blog.Features.BlogPost;

public static class BlogPostData
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
                publishDate: new DateOnly(year: 2022, month: 10, day: 9).ToDateTimeOffset(),
                lastUpdated: new DateOnly(year: 2022, month: 10, day: 9).ToDateTimeOffset(),
                numberInSeries: 1,
                "planning"),
            new(title: "Hosting on Azure",
                description: "In this post, we look at how to host Blazor Server, and where to host it.",
                pathName: "2-hosting",
                publishDate: new DateOnly(year: 2022, month: 10, day: 9).ToDateTimeOffset(),
                lastUpdated: new DateOnly(year: 2022, month: 10, day: 9).ToDateTimeOffset(),
                numberInSeries: 2,
                "hosting", "azure"),
            new(title: "Building the MVP",
                description: "In this post, we build the blog MVP, and go live!",
                pathName: "3-building-the-mvp",
                publishDate: new DateOnly(year: 2022, month: 10, day: 9).ToDateTimeOffset(),
                lastUpdated: new DateOnly(year: 2022, month: 10, day: 9).ToDateTimeOffset(),
                numberInSeries: 3,
                "prismjs", "seo"),
            new(title: "Improving Appearances",
                description: "In this post, we make the blog nicer to look at. I hope.",
                pathName: "4-improving-appearances",
                publishDate: new DateOnly(year: 2022, month: 10, day: 19).ToDateTimeOffset(),
                lastUpdated: new DateOnly(year: 2022, month: 10, day: 19).ToDateTimeOffset(),
                numberInSeries: 4,
                "mudblazor", "css", "html"),
            new(title: "Adding Comments",
                description: "In this post, we add a comment section to each blog post.",
                pathName: "5-adding-comments",
                publishDate : new DateOnly(year: 2022, month: 10, day: 22).ToDateTimeOffset(),
                lastUpdated : new DateOnly(year: 2022, month: 10, day: 22).ToDateTimeOffset(),
                numberInSeries: 5,
                "giscus", "github"),
            new(title: "SEO",
                description: "In this post, we add Search Engine Optimizations to make the blog easier to find.",
                pathName: "6-seo",
                publishDate: new DateOnly(year: 2022, month: 10, day: 22).ToDateTimeOffset(),
                lastUpdated: new DateOnly(year: 2022, month: 10, day: 22).ToDateTimeOffset(),
                numberInSeries: 6,
                "seo"),
            new (title: "Blogpost Navigation",
                description: "In this post, we add buttons to make navigating between related posts fast and easy.",
                pathName: "7-blogpost-navigation",
                publishDate: new DateOnly(year: 2023, month: 3, day: 9).ToDateTimeOffset(),
                lastUpdated: new DateOnly(year: 2023, month: 3, day: 9).ToDateTimeOffset(),
                numberInSeries: 7,
            "mudblazor"),
            new (title: "System Theme",
                description: "In this post, we update theme loading to watch for changes in the system dark-mode preference.",
                pathName: "8-system-theme",
                publishDate : new DateOnly(year: 2023, month: 3, day: 16).ToDateTimeOffset(),
                lastUpdated : new DateOnly(year: 2023, month: 3, day: 16).ToDateTimeOffset(),
                numberInSeries: 8,
                "mudblazor", "theme"),
            //new (title: "RSS Feed",
            //    description: "In this post, we add an RSS/Atom Feed to the blog to allow polling for changes.",
            //    pathName: "9-rss-feed",
            //    publishDate: new DateOnly(year: 2023, month: 3, day: 20).ToDateTimeOffset(),
            //    lastUpdated: new DateOnly(year: 2023, month: 3, day: 20).ToDateTimeOffset(),
            //    numberInSeries: 9,
            //    "rss", "atom", "xml"),
            //new (title: ".NET 8 - Blazor Web App",
            //    description: "In this post, we update the website to use dotnet 8, and take advantage of the new Blazor render modes.",
            //    pathName: "10-dotnet8",
            //    publishDate: new DateOnly(year: 2023, month: 3, day: 20).ToDateTimeOffset(),
            //    lastUpdated: new DateOnly(year: 2023, month: 3, day: 20).ToDateTimeOffset(),
            //    numberInSeries: 10,
            //    ""),
            //new (title: "",
            //    description: "",
            //    pathName: "",
            //    publishDate: new DateOnly(year: 2023, month: 3, day: 20).ToDateTimeOffset(),
            //    lastUpdated: new DateOnly(year: 2023, month: 3, day: 20).ToDateTimeOffset(),
            //    numberInSeries: 11,
            //    ""),
        }, "blazor", "dotnet");

    public static readonly BlogPostSeries[] AllBlogPostSeries = { MakingABlog };
}