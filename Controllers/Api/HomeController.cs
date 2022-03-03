using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QUERY.Data;
using QUERY.Helper;
using QUERY.Models;
using QUERY.Services.BlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace QUERY.Controllers.Api
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // service
        private readonly IBlogService _service;

        // class
        private BanyakBantuan _bantu = new();

        // tampungan objek
        private object _respon;
        private object _objek;

        // tampungan model
        private Blog _TBlog;
        //private User _TUser;
        //private Roles _TRoles;

        // tampungan string
        private string SBlog = "Blog";
        private string SUser = "User";
        private string SRoles = "Roles";

        public HomeController(IBlogService s)
        {
            _service = s;
        }

        [Route("blog")]
        public IActionResult Blog()
        {
            _objek = _service.AmbilSemuaBlog();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SBlog), _objek);
            return Ok(_respon);
        }

        [Route("blog")]
        [HttpPost]
        public IActionResult TambahBlog(string username, Blog parameternya, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _service.BuatBlogBaru(username, parameternya, Image);

                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanTambahSukses(SBlog), parameternya);
                return Ok(_respon);
            }
            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SBlog), null);
            return Ok(_respon);
        }

        [Route("blog")]
        [HttpPut]
        public IActionResult UbahBlog(Blog parameternya, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _TBlog = _service.AmbilBlogBerdasarkanId(parameternya.Id);
                if (_TBlog != null)
                {
                    _service.UbahBlog(parameternya, Image);

                    _TBlog = _service.AmbilBlogBerdasarkanId(parameternya.Id);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanUbahSukses(SBlog), _TBlog);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SBlog), null);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SBlog), null);
            return Ok(_respon);
        }

        [Route("blog/{idnya}")]
        [HttpDelete]
        public IActionResult HapusBlog(string idnya)
        {
            try
            {
                _TBlog = _service.AmbilBlogBerdasarkanId(idnya);

                if (_TBlog != null)
                {
                    _service.HapusBlog(idnya);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanHapusSukses(SBlog), _TBlog);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SBlog), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SBlog), null);
                return Ok(_respon);
            }
        }

        [Route("blog/{idnya}")]
        public IActionResult DetailBlog(string idnya)
        {
            _TBlog = _service.AmbilBlogBerdasarkanId(idnya);

            if (_TBlog != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SBlog), _TBlog);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SBlog), null);
            return Ok(_respon);
        }


        //// User
        [Route("user")]
        public IActionResult Pengguna()
        {
            _objek = _service.AmbilSemuaUser();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SUser), _objek);
            return Ok(_respon);
        }


        //// Roles
        [Route("roles")]
        public IActionResult Roles()
        {
            _objek = _service.AmbilSemuaRoles();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SRoles), _objek);
            return Ok(_respon);
        }
    }
}
