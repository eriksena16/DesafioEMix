using ConsultaCEP.Facade;
using ConsultaCEP.Models;
using ConsultaCEP.Repositories.Interface;
using ConsultaCEP.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCEP.Services.Service
{
    public class CepService : ICepService
    {
        private readonly ICepLocationFacade _cepLocationFacade;
        private readonly ICepRepository _cepRepository;
        public CepService(ICepLocationFacade cepLocationFacade, ICepRepository cepRepository)
        {
            _cepLocationFacade = cepLocationFacade;
            _cepRepository = cepRepository;
        }

        public async Task<CEP> ConsultarCep(string cep)
        {
            var obj = await _cepLocationFacade.Get(cep);

            if (!String.IsNullOrEmpty(obj.cep))
            {
                try
                {
                    await _cepRepository.AdicionarCep(obj);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro");
                }
            }
            return obj;
        }

        public async Task<List<CEP>> Listar()
        {
            List<CEP> ceps = await _cepRepository.ListarEderecos();

            return ceps;
        }

        public Task<CEP> DetalhesToCep(string cep)
        {
            cep = cep.Insert(5, "-");

            var obj = _cepRepository.ListarCep(cep);

            return obj;
        }

        public async Task<List<CEP>> ListarToUF(string uf)
        {
            List<CEP> ceps = await Listar();

            if (!string.IsNullOrEmpty(uf))
                ceps = ceps.Where(c => c.uf.Contains(uf)).ToList();

            return ceps;
        }

    }
}
