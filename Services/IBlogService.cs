using QUERY.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QUERY.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetBlogByIdAsync(string id);
        Task<Blog> AddBlogAsync(Blog newBlog);
    }
}