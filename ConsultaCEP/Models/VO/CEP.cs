using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaCEP.Models
{
    public class CEP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public long unidade { get; set; }
        public int ibge { get; set; }
        public string gia { get; set; }
    }
}
