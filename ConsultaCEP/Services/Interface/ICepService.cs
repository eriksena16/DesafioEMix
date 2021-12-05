using ConsultaCEP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultaCEP.Services.Interface
{
    public interface ICepService
    {
        Task<CEP> ConsultarCep(string cep);
        Task<CEP> DetalhesToCep(string cep);
        Task<List<CEP>> Listar();
        Task<List<CEP>> ListarToUF(string uf);
    }
}
