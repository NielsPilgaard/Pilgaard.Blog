using Markdig;
using Microsoft.AspNetCore.Components;
using Pilgaard.Blog.Models;

namespace Pilgaard.Blog.Extensions;

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

public static class BlogPostExtensions
{
    public static string GetRelativePath(this BlogPostSeries blogPostSeries, BlogPost blogPost)
    {
        return "posts/" + blogPostSeries.PathName + "/" + blogPost.PathName;
    }
}
