using Microsoft.EntityFrameworkCore;
using QUERY.Contracts.Repositories;
using QUERY.Data;
using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Blog> GetBlogByIdAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
