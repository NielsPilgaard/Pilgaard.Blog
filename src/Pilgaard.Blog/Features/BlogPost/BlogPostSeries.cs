namespace Pilgaard.Blog.Features.BlogPost;

public class BlogPostSeries
{
    public BlogPostSeries(string title,
        string description,
        string pathName,
        int order,
        BlogPost[] blogPosts,
        params string[] tags)
    {
        Title = title;
        Description = description;
        PathName = pathName;
        Order = order;
        BlogPosts = blogPosts;
        Tags = tags;
    }

    public string Title { get; }
    public string Description { get; }
    public string PathName { get; }
    public int Order { get; }
    public BlogPost[] BlogPosts { get; }
    public string[] Tags { get; }
}