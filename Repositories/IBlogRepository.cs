using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<Blog> GetBlogByIdAsync(string id);

        Task<List<Blog>> GetAllBlogsAsync();
    }
}