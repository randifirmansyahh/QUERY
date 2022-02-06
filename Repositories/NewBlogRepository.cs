using Microsoft.EntityFrameworkCore;
using QUERY.Data;
using QUERY.Models;
using QUERY.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Repositories
{
    public class NewBlogRepository : INewBlogService
    {
        private readonly AppDbContext _context;
        public NewBlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogAsync()
        {
            var result = await _context.Tb_Blog.ToListAsync();
            return result;
        }
    }
}