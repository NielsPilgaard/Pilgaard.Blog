using System.Text;

namespace Pilgaard.Blog.Features.Feed;

internal sealed class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}