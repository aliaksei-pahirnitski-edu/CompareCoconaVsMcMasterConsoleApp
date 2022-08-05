using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> ListBlogs(int topCount, bool withComments);
    }
}
