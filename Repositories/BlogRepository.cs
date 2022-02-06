using Microsoft.EntityFrameworkCore;
using QUERY.Data;
using QUERY.Helper;
using QUERY.Models;
using QUERY.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Repositories
{
    public class BlogRepository : IBlogService
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

        public async Task<bool> BuatBlogBaru(string usernamenya, Blog baru)
        {
            baru.Id = BuatPrimariKey.BuatPrimaryDenganGuild();
            baru.CreateDate = DateTime.Now;
            baru.User = CariUser(usernamenya);

            _context.Add(baru);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> UbahBlogAsync(Blog datanya)
        {
            var cari = _context.Tb_Blog.Find(datanya.Id);

            cari.Title = datanya.Title;
            cari.Content = datanya.Content;
            cari.Status = datanya.Status;

            _context.Update(cari);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<Blog> AmbilBlogBerdasarkanIdAsync(string id)
        {
            var hasil = await _context.Tb_Blog
                                      .Include(x=>x.User)
                                      .FirstOrDefaultAsync(x => x.Id == id);
            return hasil;
        }

        public async Task<bool> HapusBlogAsync(string idnya)
        {
            var cari = _context.Tb_Blog.Find(idnya);

            _context.Remove(cari);
            await _context.SaveChangesAsync();

            return true;
        }

        private User CariUser(string usernamenya)
        {
            return _context.Tb_User.FirstOrDefault(x => x.Username == usernamenya);
        }

        private Blog CariBlog(string idnya)
        {
            return _context.Tb_Blog.FirstOrDefault(x => x.Id == idnya);
        }
    }
}