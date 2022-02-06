using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Services
{
    public interface INewBlogService
    {
        Task<List<Blog>> GetAllBlogAsync();
    }
}
