using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Services
{
    public class FileService
    {
        IWebHostEnvironment _alat;
        public FileService(IWebHostEnvironment e)
        {
            _alat = e;
        }

        public async Task<string> SimpanFile(IFormFile filenya)
        {
            string namaFolder = "namaFoldernya";
            
            // cek filenya
            if (filenya == null)
            {
                // return string kosong
                return string.Empty;
            }

            // set di wwwroot/namaFolder
            var savepath = Path.Combine(_alat.WebRootPath, namaFolder);

            // cek foldernya ada atau tidak
            if (!Directory.Exists(savepath))
            {
                // jika tidak maka dibuat foldernya
                Directory.CreateDirectory(savepath);
            }

            // set nama file
            var namaFilenya = filenya.FileName;
            // set alamat file
            var alamatFilenya = Path.Combine(savepath, namaFilenya);

            // proses copy file ke folder
            using (var stream = new FileStream(alamatFilenya, FileMode.Create))
            {
                await filenya.CopyToAsync(stream);
            }

            // return alamat file
            return Path.Combine("/" + namaFolder + "/", namaFilenya);
        }
    }
}
