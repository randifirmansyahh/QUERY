using QUERY.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Models
{
    public class ContohModelUntukValidasi
    {
        [Required(ErrorMessage = "Harus diisi")] // bisa di tumpuk
        [StringLength(12, MinimumLength = 3, ErrorMessage = "kalimatnya max 12 minimal 3")] // panjang inputan
        public string MaksimalKata { get; set; }


        // isi harus sesuai parameter
        [ValidasiBuatan("IsiTerserah")] // validasi dari helper
        public string IsiHarusSesuai { get; set; }


        [Range(1, 100, ErrorMessage = "hanya 1 sampai 100")] // range angka
        public int RangeAngka { get; set; }


        [EmailAddress(ErrorMessage = "email yang bener")]
        public string ValidasiEmail { get; set; }


        [RegularExpression(@"^[0-9]*$", ErrorMessage = "angka aja wey")]
        public int HanyaAngka { get; set; }


        [RegularExpression(@"^[a-z]*$", ErrorMessage = "huruf kecil aja wey")]
        public string HurufKecilAja { get; set; }


        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "huruf aja wey")]
        public string HurufAja { get; set; }


        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "nomer hp wey")]
        public int NomorHp { get; set; }


        // untuk membandingkan
        [Compare("Bandingan2", ErrorMessage = "Tidak sama")]
        public string Bandingan1 { get; set; }
        public string Bandingan2 { get; set; }


        [Url(ErrorMessage = "url yang bener")]
        public string Url { get; set; }

        // tinggal ganti angkanya
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "contoh 123-123-1234")] // Format: 123-123-1234
        public string AdaStripnya { get; set; }
    }
}
