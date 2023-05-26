namespace Pilgaard.Blog.Features.Feed;

public static class DateOnlyExtensions
{
    public static DateTimeOffset ToDateTimeOffset(this DateOnly dateOnly)
        => new(dateOnly.ToDateTime(new TimeOnly(0, 0, 0)));
}