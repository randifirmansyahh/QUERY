using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> AmbilSemuaBlogAsync();
        Task<bool> BuatBlogBaru(string usernamenya, Blog baru);
        Task<bool> UbahBlogAsync(Blog dariView);
        Task<Blog> AmbilBlogBerdasarkanIdAsync(string id);
    }
}
