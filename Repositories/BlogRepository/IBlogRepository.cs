using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Repositories.BlogRepository
{
    public interface IBlogRepository
    {
        // BLOG
        Task<List<Blog>> AmbilSemuaBlogAsync();
        Task<bool> BuatBlogBaruAsync(Blog baru);
        Task<bool> UbahBlogAsync(Blog datanya);
        Task<Blog> AmbilBlogBerdasarkanIdAsync(string id);
        Task<bool> HapusBlogAsync(Blog datanya);
        Task<User> CariUserAsync(string usernamenya);
        Task<Blog> CariBlogAsync(string idnya);

        // USER
        Task<List<User>> AmbilSemuaUserAsync();
        Task<User> AmbilUserByUsernameAsync(string usernamenya);

        // ROLES
        Task<List<Roles>> AmbilSemuaRolesAsync();
        Task<Roles> AmbilRolesByIdAsync(string idnya);
    }
}
