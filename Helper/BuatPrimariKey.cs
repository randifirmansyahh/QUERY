using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Helper
{
    public class BuatPrimariKey
    {
        public static string Buat(string user,DateTime parameter)
        {
            return user + parameter.Ticks.ToString("x");
        }
    }
}