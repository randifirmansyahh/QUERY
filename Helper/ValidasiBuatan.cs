using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Helper
{
    public class ValidasiBuatan : ValidationAttribute
    {
        public string _Kalimatnya { get; }
        public ValidasiBuatan(string k)
        {
            _Kalimatnya = k;
        }

        // pesan errornya
        // return string dengan gaya
        
        public string PesanError() => $"Ga ada kata '{_Kalimatnya}' nya.";

        protected override ValidationResult IsValid(object nilai, ValidationContext KonteksValidasinya)
        {
            var kalimat = nilai.ToString();

            if (!kalimat.Contains(_Kalimatnya)) // contain artinya mengandung
            {
                return new ValidationResult(PesanError());
            }

            return ValidationResult.Success;
        }
    }
}
