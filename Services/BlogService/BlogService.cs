using Microsoft.AspNetCore.Http;
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
        private readonly FileService _file;

        public BlogService(IBlogRepository blogRepo, FileService f)
        {
            _blogRepo = blogRepo;
            _file = f;
        }

        public Blog AmbilBlogBerdasarkanId(string id)
        {
            return _blogRepo.AmbilBlogBerdasarkanIdAsync(id).Result;
        }

        public List<Blog> AmbilSemuaBlog()
        {
            return _blogRepo.AmbilSemuaBlogAsync().Result;
        }

        public bool BuatBlogBaru(string usernamenya, Blog baru, IFormFile Image)
        {
            baru.Id = BuatPrimariKey.BuatPrimaryDenganGuild();
            baru.CreateDate = DateTime.Now;
            baru.User = _blogRepo.CariUserAsync(usernamenya).Result;
            baru.Image = _file.SimpanFile(Image).Result;

            return _blogRepo.BuatBlogBaruAsync(baru).Result;
        }

        public bool HapusBlog(string idnya)
        {
            var cari = _blogRepo.CariBlogAsync(idnya).Result;
            return _blogRepo.HapusBlogAsync(cari).Result;
        }

        public bool UbahBlog(Blog dariView, IFormFile Image)
        {
            var cari = _blogRepo.CariBlogAsync(dariView.Id).Result;

            if (cari != null)
            {
                // dinamis
                cari.Title = dariView.Title;
                cari.Content = dariView.Content;
                cari.Status = dariView.Status;

                // statis
                cari.CreateDate = cari.CreateDate;
                cari.User = cari.User;

                // cek
                if (Image != null) cari.Image = _file.SimpanFile(Image).Result;
                else cari.Image = cari.Image;

                return _blogRepo.UbahBlogAsync(cari).Result;
            }
            return false;
        }




        // User
        public List<User> AmbilSemuaUser()
        {
            return _blogRepo.AmbilSemuaUserAsync().Result;
        }

        public User AmbilUserByUsername(string usernamenya)
        {
            return _blogRepo.AmbilUserByUsernameAsync(usernamenya).Result;
        }



        // Roles
        public List<Roles> AmbilSemuaRoles()
        {
            return _blogRepo.AmbilSemuaRolesAsync().Result;
        }

        public Roles AmbilRolesById(string idnya)
        {
            return _blogRepo.AmbilRolesByIdAsync(idnya).Result;
        }

    }
}
