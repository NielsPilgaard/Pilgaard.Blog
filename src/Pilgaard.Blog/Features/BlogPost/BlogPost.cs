namespace Pilgaard.Blog.Features.BlogPost;

public class BlogPost
{
    public BlogPost(string title,
        string description,
        string pathName,
        DateTimeOffset publishDate,
        DateTimeOffset lastUpdated,
        int numberInSeries = 1,
        params string[] tags)
    {
        Title = title;
        Description = description;
        PathName = pathName;
        PublishDate = publishDate;
        LastUpdated = lastUpdated;
        NumberInSeries = numberInSeries;
        Tags = tags;
    }

    public string Title { get; }
    public string Description { get; }
    public string PathName { get; }
    public DateTimeOffset PublishDate { get; }
    public DateTimeOffset LastUpdated { get; }
    public int NumberInSeries { get; }
    public string[] Tags { get; }
}