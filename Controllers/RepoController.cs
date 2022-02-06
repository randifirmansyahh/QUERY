using Microsoft.AspNetCore.Mvc;
using QUERY.Contracts.Services;
using QUERY.Models;
using QUERY.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QUERY.Controllers
{
    public class RepoController : Controller
    {
        private readonly INewBlogService _blogService;
        public RepoController(INewBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ActionResult<List<Blog>>> GetAllBlogs()
        {
            return await _blogService.GetAllBlogAsync();
        }
    }
}