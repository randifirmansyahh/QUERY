using Microsoft.AspNetCore.Http;
using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Services.BlogService
{
    public interface IBlogService
    {
        // blog
        List<Blog> AmbilSemuaBlog();
        bool BuatBlogBaru(string usernamenya, Blog baru, IFormFile Image);
        bool UbahBlog(Blog dariView, IFormFile Image);
        Blog AmbilBlogBerdasarkanId(string id);
        bool HapusBlog(string idnya);

        // user
        List<User> AmbilSemuaUser();
        User AmbilUserByUsername(string usernamenya);

        // roles
        List<Roles> AmbilSemuaRoles();
        Roles AmbilRolesById(string idnya);
    }
}
