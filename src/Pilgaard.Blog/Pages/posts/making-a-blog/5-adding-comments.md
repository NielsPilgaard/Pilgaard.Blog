I decided on using <a href="https://giscus.app/" target="_blank">Giscus</a> as my commenting system, as it seemed the simplest and easiest to set up.

To set up Giscus, there are a few prerequisites:

- A public GitHub repository. You can think of this as the storage for your comments.
- The [Giscus](https://github.com/apps/giscus) app must be installed in your repository.
- The Discussions feature must be turned on by <a href="https://docs.github.com/en/github/administering-a-repository/managing-repository-settings/enabling-or-disabling-github-discussions-for-a-repository" target="_blank">
  enabling it in your repository.</a> It is not enabled by default.

Adding it to a Blazor website isn't as straight forward as following the guide though,
and after a lot of head-scratching,
<a href="https://github.com/giscus/giscus/issues/740" target="_blank">
I made an issue
</a>
on the Giscus issue tracker asking for help. They quickly answered and got me back on track.

## GiscusBlazor

There's a Giscus Blazor component!

<a href="https://github.com/Jisu-Woniu/giscus-blazor" target="_blank">
    https://github.com/Jisu-Woniu/giscus-blazor
</a>

To set it up, start by adding the nuget `GiscusBlazor`:

```shell
dotnet add package GiscusBlazor
```

Then import the required script in your `\_Layout.cshtml`:

```cshtml
<script type="module" src="https://cdn.esm.sh/giscus?bundle"></script>
```

Lastly, in order to add the comment area to your page, add this:

```cshtml
<Giscus Repo="[ENTER REPO HERE]"
    RepoId="[ENTER REPO ID HERE]"
    Category="[ENTER CATEGORY NAME HERE]"
    CategoryId="[ENTER CATEGORY ID HERE]"
    Mapping="Mapping.Specific"
    Term="[ENTER TERM HERE]"
    ReactionsEnabled="true"
    EmitMetadata="false"
    InputPosition="InputPosition.Bottom"
    Theme="light"
    Lang="en"
    Loading="Loading.Lazy" />
```

The required values can easily be configured using the Configuration section on
<a href="https://giscus.app/" target="_blank">
https://giscus.app/
</a>

In my case, it looked like this:

```cshtml
@using GiscusBlazor
<Giscus Repo="NielsPilgaard/Pilgaard.Blog"
    RepoId="R_kgDOIHUfWQ"
    Category="Announcements"
    CategoryId="DIC_kwDOIHUfWc4CSFPf"
    Mapping="Mapping.PathName"
    Term="Welcome to giscus-blazor!" # No idea what this does
    ReactionsEnabled="true"
    EmitMetadata="false"
    InputPosition="InputPosition.Top"
    Theme="preferred_color_scheme"
    Lang="en"
    Loading="Loading.Lazy" />
```

## Styling

To pretty up the comment section I added this bit to my `site.css`:

```css
.giscus-frame {
    margin-top: 24px;
    width: 100%;
    display: block;
    box-sizing: border-box;
    margin-left: auto;
    margin-right: auto;
}

@media screen and (min-width: 600px) {
    .giscus-frame {
    padding-left: 24px;
    padding-right: 24px;
    margin-bottom: 12px;
        }
    }
}
```

## Summary

We learned how to add a comment area to a page using
<a href="https://giscus.app/" target="_blank">Giscus</a>
and
<a href="https://github.com/Jisu-Woniu/giscus-blazor" target="_blank">GiscusBlazor</a>, by leveraging the GitHub Discussions API.

Now that it's possible, I hope you'll leave a comment or reaction below 😄

### See the code

[Pull Request implementing the changes in this post](https://github.com/NielsPilgaard/Pilgaard.Blog/pull/15)

### The state of the blog

**This post**
![State of the blog](https://user-images.githubusercontent.com/21295394/224504686-85114dcd-bd0b-4573-a647-fc18eafd45df.png)

**Comment section**
![Comment Section](https://user-images.githubusercontent.com/21295394/224504695-bc751901-74a6-4f3d-af08-e3ab75e42e8e.png)
