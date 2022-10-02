using Pilgaard.Blog.Extensions;

await WebApplication.CreateBuilder(args)
    .ConfigureServices(args)
    .ConfigureRequestPipeline(args)
    .RunAsync();