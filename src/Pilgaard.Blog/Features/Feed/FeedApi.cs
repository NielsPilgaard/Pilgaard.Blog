using Microsoft.SyndicationFeed;
using System.Xml;
using Microsoft.SyndicationFeed.Atom;
using Pilgaard.Blog.Features.BlogPost;
using Pilgaard.Blog.Features.SEO;

namespace Pilgaard.Blog.Features.Feed;

public static class FeedApi
{
    public static WebApplication MapRssFeed(this WebApplication app)
    {
        app.MapGet("/feed.xml", async (HttpContext context) =>
        {
            context.Response.ContentType = "application/xml";

            var stringWriter = new Utf8StringWriter();

            await using var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings
            {
                Async = true,
                Indent = true
            });

            var writer = new AtomFeedWriter(xmlWriter);

            await writer.WriteTitle(DefaultMetadata.Title);

            var lastUpdated = BlogPostData
                .AllBlogPostSeries
                .SelectMany(blogPostSeries => blogPostSeries.BlogPosts.Select(blogPost => blogPost.LastUpdated))
                .Max();

            await writer.WriteUpdated(lastUpdated);
            await writer.Write(new SyndicationLink(new Uri(FeedConstants.BlogUrl)));

            foreach (var blogPostSeries in BlogPostData.AllBlogPostSeries)
            {
                foreach (var blogPost in blogPostSeries.BlogPosts)
                {
                    var link = $"{FeedConstants.BlogUrl}/{blogPostSeries.GetRelativePath(blogPost)}";
                    var item = new SyndicationItem
                    {
                        Id = link,
                        Title = blogPost.Title,
                        Description = blogPost.Description,
                        Published = blogPost.PublishDate,
                        LastUpdated = blogPost.LastUpdated,
                    };

                    item.AddLink(new SyndicationLink(new Uri(link)));
                    item.AddContributor(new SyndicationPerson("Niels Pilgaard Grøndahl", "niels.pilgaard@hotmail.com"));
                    foreach (var blogPostTag in blogPost.Tags)
                    {
                        item.AddCategory(new SyndicationCategory(blogPostTag));
                    }

                    await writer.Write(item);
                }
            }

            // This closes the <content> element
            await xmlWriter.WriteEndElementAsync();

            await xmlWriter.FlushAsync();

            return stringWriter.ToString();
        });

        return app;
    }
}