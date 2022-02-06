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
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogRepository.GetAllBlogsAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(string id)
        {
            return await _blogRepository.GetBlogByIdAsync(id);
        }

        public async Task<Blog> AddBlogAsync(Blog newBlog)
        {
            return await _blogRepository.AddAsync(newBlog);
        }
    }
}
