using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QUERY.Helper;
using QUERY.Models;
using QUERY.Services.BlogService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QUERY.Controllers
{
    [Authorize]
    [Route("repo")]
    public class RepoController : Controller
    {
        private readonly IBlogService _blog;

        public RepoController(IBlogService blog)
        {
            _blog = blog;
        }

        [Route("semua")]
        public async Task<ActionResult<List<Blog>>> TampilkanSemuaBlog()
        {
            return View("Index", await _blog.AmbilSemuaBlogAsync());
        }

        [Route("buat")]
        public IActionResult Buat()
        {
            return View();
        }

        [HttpPost]
        [Route("buat")]
        public async Task<ActionResult<Blog>> BuatBlog(Blog dariView)
        {
            if (ModelState.IsValid)
            {
                string username = User.GetUsername().ToString(); // dari helper
                await _blog.BuatBlogBaru(username, dariView);
                return RedirectToAction("semua");
            }
            return View("Buat", dariView);
        }

        [Route("ubah/{id}")]
        public async Task<ActionResult<Blog>> UbahBlog(string id)
        {
            return View("Ubah", await _blog.AmbilBlogBerdasarkanIdAsync(id));
        }

        [HttpPost]
        [Route("ubah")]
        public async Task<ActionResult<Blog>> UbahBlog(Blog dariView)
        {
            if (ModelState.IsValid)
            {
                await _blog.UbahBlogAsync(dariView);
                return Redirect("detail/" + dariView.Id);
            }
            return View(dariView);
        }

        [Route("detail/{id}")]
        public async Task<ActionResult<Blog>> DetailBlog(string id)
        {
            return View("Detail", await _blog.AmbilBlogBerdasarkanIdAsync(id));
        }

        [Route("hapus/{id}")]
        public async Task<ActionResult> HapusBlog(string id)
        {
            await _blog.HapusBlogAsync(id);
            return RedirectToAction("semua");
        }
    }
}