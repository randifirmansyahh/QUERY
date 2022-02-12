using Microsoft.EntityFrameworkCore;
using QUERY.Data;
using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;
        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> AmbilSemuaBlogAsync()
        {
            var result = await _context.Tb_Blog
                                       .Include(x => x.User)
                                       .ToListAsync();
            return result;
        }

        public async Task<bool> BuatBlogBaruAsync(Blog baru)
        {
            _context.Add(baru);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UbahBlogAsync(Blog datanya)
        {
            _context.Update(datanya);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Blog> AmbilBlogBerdasarkanIdAsync(string id)
        {
            var hasil = await _context.Tb_Blog
                                      .Include(x => x.User)
                                      .FirstOrDefaultAsync(x => x.Id == id);
            return hasil;
        }

        public async Task<bool> HapusBlogAsync(Blog datanya)
        {
            _context.Remove(datanya);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> CariUserAsync(string usernamenya)
        {
            return await _context.Tb_User.FirstOrDefaultAsync(x => x.Username == usernamenya);
        }

        public async Task<Blog> CariBlogAsync(string idnya)
        {
            return await _context.Tb_Blog.FirstOrDefaultAsync(x => x.Id == idnya);
        }
    }
}
