using Microsoft.EntityFrameworkCore;
using Services.EF;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Seed
{
    public static class SeedHelper
    {
        public static void TrySeedIfEmpty(this BlogContext dbContext)
        {
            lock (typeof(SeedHelper))
            {
                var isSuccess = dbContext.Database.EnsureCreated();

                // dbContext.Database.Migrate();

                if (!dbContext.Blogs.Any())
                {
                    var sampleBlogs = SampleBlogsWithComments();
                    dbContext.Blogs.AddRange(sampleBlogs);
                    dbContext.SaveChanges();
                }
            }
        }

        public static List<Blog> SampleBlogsWithComments() => new List<Blog>
        {
            new Blog
            {
                Id = 1,
                Title = "First Blog",
                Content = "This is first blog",
                CreatedAt = new DateTime(2021, 05, 15, 11, 25, 00),
                Comments = new List<Comment>
                {
                    new Comment()
                    {
                        Id = 1001,
                        Text = "very good comment",
                        CreatedAt = new DateTime(2021, 05, 15, 12, 28, 00),
                    },
                    new Comment()
                    {
                        Id = 1002,
                        Text = "additional comment for first blog",
                        CreatedAt = new DateTime(2021, 06, 13, 14, 39, 00),
                    },
                }
            },

            new Blog
            {
                Id = 2,
                Title = "Second Blog",
                Content = "This is blog about kitchen",
                CreatedAt = new DateTime(2021, 07, 13, 11, 18, 00),
                Comments = new List<Comment>
                {
                    new Comment()
                    {
                        Id = 1005,
                        Text = "very tasty",
                        CreatedAt = new DateTime(2021, 08, 15, 12, 28, 00),
                    },
                    new Comment()
                    {
                        Id = 1006,
                        Text = "add milk and cheese",
                        CreatedAt = new DateTime(2021, 09, 13, 17, 41, 00),
                    },
                    new Comment()
                    {
                        Id = 1007,
                        Text = "add oil with onion",
                        CreatedAt = new DateTime(2021, 09, 14, 16, 42, 00),
                    },
                }
            },

            new Blog
            {
                Id = 3,
                Title = "Third Blog",
                Content = "This is dummy third blog",
                CreatedAt = new DateTime(2021, 08, 08, 10, 20, 00),
                Comments = new List<Comment>
                {
                }
            },

            new Blog
            {
                Id = 4,
                Title = "Four Blog",
                Content = "This is programming blog",
                CreatedAt = new DateTime(2021, 12, 17, 09, 16, 00),
                Comments = new List<Comment>
                {
                    new Comment()
                    {
                        Id = 1010,
                        Text = "C# is cool lang",
                        CreatedAt = new DateTime(2021, 12, 18, 12, 22, 00),
                    },
                    new Comment()
                    {
                        Id = 1011,
                        Text = "New code generation feature",
                        CreatedAt = new DateTime(2022, 01, 17, 19, 52, 00),
                    },
                }
            },


        };
    }
}
