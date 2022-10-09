using Markdig;
using Microsoft.AspNetCore.Components;

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
