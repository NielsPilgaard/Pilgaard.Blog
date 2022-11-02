namespace Pilgaard.Blog.Features.BlogPost;

public static class BlogPostExtensions
{
    public static string GetRelativePath(this BlogPostSeries blogPostSeries, BlogPost blogPost)
    {
        return "posts/" + blogPostSeries.PathName + "/" + blogPost.PathName;
    }
}