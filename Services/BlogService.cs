using QUERY.Contracts.Repositories;
using QUERY.Contracts.Services;
using QUERY.Models;
using QUERY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepositoryContainer repo;

        public BlogService(IRepositoryContainer _repo)
        {
            repo = _repo;
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await repo.Blog.GetAllBlogsAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(string id)
        {
            return await repo.Blog.GetBlogByIdAsync(id);
        }

        public async Task<Blog> AddBlogAsync(Blog newBlog)
        {
            return await repo.Blog.AddAsync(newBlog);
        }
    }
}
