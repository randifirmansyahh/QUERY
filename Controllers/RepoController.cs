using Microsoft.AspNetCore.Mvc;
using QUERY.Models;
using QUERY.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QUERY.Controllers
{
    public class RepoController : Controller
    {
        private readonly IBlogService _blogService;
        public RepoController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ActionResult<List<Blog>>> GetAllBlogs()
        {
            return await _blogService.GetAllBlogsAsync();
        }
    }
}