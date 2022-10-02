# Making a blog with C# - Part 1

I've been wanting to try out Blazor for a while now, so I decided 
on making a blog with it, so I could share my experienes along the way.

To share as much of the experience as possible, I'm going to make the blog available as
soon as it's functional - Meaning there's a good chance it's rough on the eyes at first. Sorry :D

I'll be improving on the blog gradually and making posts about it along the way. 

**The plan:**

1) Pick tools
2) Setup hosting
3) Setup git & CI/CD
4) Blog website MVP - *probably just a page with text* :sweat_smile:
5) Publish website
6) Add links to GitHub, Twitter, LinkedIn etc
7) Improve appearance of the website
8) Get a custom domain
9) Search Engine Optimizations (SEO)
10) Allow people to subscribe to get notifications about new posts
11) A system that allows me to make and publish new blog posts directly on the website
12) ???

Let's see how far that plan takes us!

---

## Picking tools

Blazor is a given, but whether to use Blazor Server or Web Assembly was a hard choice.

I started out with Blazor WASM, but I got a bit overwhelmed by all the unknowns. 
I want to try new things with this project, but at a slow pace.

I usually work with dotnet 6 worker services, so Blazor Server felt like a better fit for me.

### Hosting

I decided on using Azure - it feels like the natural choice for dotnet, and I've used it a bit in the past. 

AWS was also on the table, but I prefer to avoid it, due to the labouring practices of other parts of Amazon.

A static website host didn't feel quite technical enough for what I wanted to do.

### Database

A goal of mine is to serve posts through a database I haven't used in production before. 

The databases I considered were MongoDb, Azure Cosmos Db and AWS DynamoDb.

After looking at pricing, I decided on Azure Cosmos Db to stick with Azure, as they were all fairly similar.


## Summary

What I ended up with, was the following resources in Azure:

- SignalR Service (Free-tier)
- App Service (Free-tier)
- Cosmos Db (Serverless, almost free)
- KeyVault (Almost free)

If I'm lucky then I'll have to upgrade those eventually :D

---

## Personal Goals with this project

- I want to improve my communication skills, especially when it comes to knowledge sharing and story telling.
- Create a space where I feel I share my development experiences.
    - I find it really hard to put myself out there, so I'm hoping this blog will help me overcome that.

---

Thanks a lot for reading, I hope to see you in the next post :smiley:



Twitter: [@NillerMedDild](https://twitter.com/NillerMedDild)

GitHub: [NielsPilgaard](https://github.com/NielsPilgaard)