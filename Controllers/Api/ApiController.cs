using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QUERY.Data;
using QUERY.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace QUERY.Controllers.Api
{
    public class ApiController : Controller
    {
        private readonly AppDbContext _c;
        public ApiController(AppDbContext a)
        {
            _c = a;
        }

        public IActionResult Blog()
        {
            Object cari = _c.Tb_Blog.Include(x => x.User).Include(x => x.User.Roles);

            object hasil = BanyakBantuan.BuatResponAPI(200, "Berhasil ambil data blog", cari);
            return Ok(hasil);
        }

        public IActionResult Pengguna()
        {
            Object cari = _c.Tb_User.Include(x => x.Roles);

            object hasil = BanyakBantuan.BuatResponAPI(200, "Berhasil ambil data user", cari);
            return Ok(hasil);
        }

        public IActionResult Roles()
        {
            Object cari = _c.Tb_Roles;

            object hasil = BanyakBantuan.BuatResponAPI(200, "Berhasil ambil data roles", cari);
            return Ok(hasil);
        }
    }
}
