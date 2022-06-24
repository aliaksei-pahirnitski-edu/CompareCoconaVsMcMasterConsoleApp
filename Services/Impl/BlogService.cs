using Microsoft.EntityFrameworkCore;
using Services.EF;
using Services.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    class BlogService : IBlogService
    {
        private readonly BlogContext _dbCtx;

        public BlogService(BlogContext dbContext)
        {
            _dbCtx = dbContext;
        }

        public async Task<List<Blog>> ListBlogs(int topCount)
        {
            return await _dbCtx.Blogs.OrderByDescending(x => x.CreatedAt).Take(topCount).ToListAsync();
        }
    }
}
