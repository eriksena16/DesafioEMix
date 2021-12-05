using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCEP.Models
{
    public class ViaCepOptions
    {
        public static string Instance { get; } = "VIACEP";
        public string BaseAddress { get; set; }
        public string RequestUriCep { get; set; }
    }
}
