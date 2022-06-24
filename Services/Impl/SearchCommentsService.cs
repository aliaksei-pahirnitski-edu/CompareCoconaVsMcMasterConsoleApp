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
    class SearchCommentsService : ISearchCommentsService
    {
        private readonly BlogContext _dbCtx;

        public SearchCommentsService(BlogContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public async Task<List<Comment>> Search(string word)
        {
            return await _dbCtx.Set<Comment>()
                .Where(x => x.Text.Contains(word))
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
