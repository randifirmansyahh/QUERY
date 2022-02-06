using Microsoft.AspNetCore.Mvc;
using QUERY.Models;
using QUERY.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QUERY.Controllers
{
    [Route("repo")]
    public class RepoController : Controller
    {
        private readonly IBlogService _blogService;

        public RepoController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [Route("semua")]
        public async Task<ActionResult<List<Blog>>> TampilkanSemuaBlog()
        {
            return View("Index", await _blogService.AmbilSemuaBlogAsync());
        }

        [Route("cari/{id}")]
        public async Task<ActionResult<Blog>> TampilkanBlogBerdasarkanID(string id)
        {
            return View("Detail", await _blogService.AmbilBlogBerdasarkanIdAsync(id));
        }
    }
}