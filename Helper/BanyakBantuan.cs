using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Helper
{
    public class BanyakBantuan
    {
        public static int BuatOTP()
        {
            // agar nilainya teracak terus
            Random mulai = new Random();

            // agar 4 digit angka
            int nilainya = mulai.Next(1000, 9999);
            return nilainya;
        }
    }
}
