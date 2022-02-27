using Microsoft.AspNetCore.Mvc;
using QUERY.Models;
using QUERY.Services.BlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IBlogService _blog;
        public AjaxController(IBlogService blog)
        {
            _blog = blog;
        }
        public async Task<List<Blog>> Index()
        {
            return await _blog.AmbilSemuaBlogAsync();
        }
    }
}
