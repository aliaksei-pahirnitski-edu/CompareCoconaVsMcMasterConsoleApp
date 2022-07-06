using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Services.EF;
using System;
using Services.Interfaces;
using Services.Impl;
using System.Collections.Generic;

namespace Services
{
    public static class RegisterDI
    {
        public static void AddBlogServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ISearchCommentsService, SearchCommentsService>();
        }

        public static void AddInMemoryBlogs(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>(opt =>
            {
                opt.UseInMemoryDatabase("CompareConsoleApp");
            });
        }
        public static void AddSqLiteBlogs(this IServiceCollection/*IList<ServiceDescriptor>*/ services)
        {
            services.AddDbContext<BlogContext>(opt =>
            {
                opt.UseSqlite("Filename=CompareConsoleApp.db");
            });
        }
    }
}
