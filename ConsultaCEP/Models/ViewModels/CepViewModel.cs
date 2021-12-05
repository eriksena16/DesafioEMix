using System.ComponentModel.DataAnnotations;

namespace ConsultaCEP.Models.ViewModels
{
    public class CepViewModel
    {
        [Display(Name ="CEP")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string cep { get; set; }
        [Display(Name = "CEP")]
        public string logradouro { get; set; }
        [Display(Name = "Complemento")]
        public string complemento { get; set; }
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        [Display(Name = "Localidade")]
        public string localidade { get; set; }
        [Display(Name = "UF")]
        public string uf { get; set; }
        [Display(Name = "Unidade")]
        public long unidade { get; set; }
        [Display(Name = "IBGE")]
        public int ibge { get; set; }
        [Display(Name ="GIA")]
        public string gia { get; set; }
        public string CurrentSort { get; set; }

    }
}
