namespace Pilgaard.Blog.Models
{
    public record BlogPostSeries(
        string DisplayName,
        string PathName,
        int Order,
        BlogPost[] BlogPosts,
        params string[] Tags)
    {
        public string GetRelativePath(BlogPost blogPost)
        {
            return "posts/" + PathName + "/" + blogPost.PathName;
        }
    }
}
