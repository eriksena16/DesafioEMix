using ConsultaCEP.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultaCEP.Repositories.Interface
{
    public interface ICepRepository : IDisposable
    {
        Task AdicionarCep(CEP cep);
        Task<List<CEP>> ListarCeps();
        Task<bool> Exists(string cep);
    }
}
