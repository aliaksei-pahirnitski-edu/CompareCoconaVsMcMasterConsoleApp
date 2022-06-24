using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.EF;
using Services.Entities;
using Services.Interfaces;
using Services.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompareMcMasterVsCoconaConsoleApp
{
    class Program
    {
        const string Help = @"
            Commands: help, hallo, blog, comment
            help - prints this
            hallo [-n][--name]  - greets by name
            comment [--query=search word]
            blog has subcommands

            blog list [count=3] [-c - with comments or without by default], ex:
            blog list -c 2
    
            blog add [--title] [--text]
            blog addComment [--blogId] [--content]
";

        // questions:
        // 1 - are commands and params case sensitive? ex: HALLO --name=alex or Hallo --Name=lesha
        // 2 - example with async
        // 3 - with using dependency injection and appsettings configuration
        // 4 - order of params ex: blog add --title=A --text=B vs blog add --text=B --title=A 
        // 5 - order of options and params, extra spaces, params without name and etc (blog list -c 2)
        // 6 - sub-commands

        static async Task Main(string[] args)
        {
            // Here straightforward implementation without any helper nuget (without McMaster nor Cocona)
            var validCommands = new List<string>
            {
                "help",
                "hallo",
                "blog",
                "comment"
            };
            if (args.Length == 0 || !validCommands.Contains(args[0])){
                Console.WriteLine(Help);
                return;
            }

            var di = new ServiceCollection();
            // di.AddInMemoryBlogs();
            di.AddSqLiteBlogs();
            di.AddBlogServices();
            var services = di.BuildServiceProvider();

            var dbCtx = services.GetRequiredService<BlogContext>();
            dbCtx.TrySeedIfEmpty();

            var testCommentFinder = services.GetRequiredService<ISearchCommentsService>();
            var _comments = await testCommentFinder.Search("comment");

            var testBlogService = services.GetRequiredService<IBlogService>();
            var _blogs = await testBlogService.ListBlogs(2);

            var command = args[0];
            switch (command)
            {
                case "hallo":
                    var name = args.Length > 1 ? args[1] : "Friend";
                    Console.WriteLine($"Hi {name}");
                    return;

                case "comment":
                    var query = "";
                    if (args.Length >= 1)
                    {
                        if (args[1].StartsWith("--query="))
                        {
                            query = args[1].Substring("--query=".Length);
                        }
                    }
                    if (string.IsNullOrWhiteSpace(query))
                    {
                        Console.WriteLine($"Searching skipped as no query word");
                    }
                    else
                    {
                        Console.WriteLine($"Searching comments by [{query}]");
                        var commentFinder = services.GetRequiredService<ISearchCommentsService>();
                        var comments = await commentFinder.Search(query);
                        Console.WriteLine($"Found [{comments.Count}] comments");
                        foreach(var topComment in comments.Take(3))
                        {
                            Console.WriteLine($"[Blog {topComment.BlogId}]: [{topComment.CreatedAt:yyyy-MM-dd HH:mm}] {topComment.Text} ");
                        }
                    }
                    return;

                case "blog":
                    Console.WriteLine("todo blog");
                    return;

                default:
                    Console.WriteLine(Help);
                    return;
            }
        }
    }
}
