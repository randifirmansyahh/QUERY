using QUERY.Helper;
using QUERY.Models;
using QUERY.Repositories.BlogRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Services.BlogService
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepo;
        public BlogService(IBlogRepository blogRepo)
        {
            _blogRepo = blogRepo;
        }

        public async Task<Blog> AmbilBlogBerdasarkanIdAsync(string id)
        {
            return await _blogRepo.AmbilBlogBerdasarkanIdAsync(id);
        }

        public async Task<List<Blog>> AmbilSemuaBlogAsync()
        {
            return await _blogRepo.AmbilSemuaBlogAsync();
        }

        public async Task<bool> BuatBlogBaru(string usernamenya, Blog baru)
        {
            baru.Id = BuatPrimariKey.BuatPrimaryDenganGuild();
            baru.CreateDate = DateTime.Now;
            baru.User = await _blogRepo.CariUserAsync(usernamenya);

            return await _blogRepo.BuatBlogBaruAsync(baru);
        }

        public async Task<bool> HapusBlogAsync(string idnya)
        {
            var cari = await _blogRepo.CariBlogAsync(idnya);
            return await _blogRepo.HapusBlogAsync(cari);
        }

        public async Task<bool> UbahBlogAsync(Blog dariView)
        {
            var cari = await _blogRepo.CariBlogAsync(dariView.Id);

            cari.Title = dariView.Title;
            cari.Content = dariView.Content;
            cari.Status = dariView.Status;

            return await _blogRepo.UbahBlogAsync(cari);
        }
    }
}
