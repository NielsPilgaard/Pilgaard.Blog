namespace Pilgaard.Blog.Models;

public readonly record struct BlogPost(
    string DisplayName,
    string PathName,
    DateOnly PublishDate,
    int NumberInSeries = 1,
    params string[] Tags);