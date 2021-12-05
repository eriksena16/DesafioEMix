using ConsultaCEP.Facade;
using ConsultaCEP.Models;
using ConsultaCEP.Repositories.Interface;
using ConsultaCEP.Services.Interface;
using System;
using System.Collections.Generic;
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
            if (!String.IsNullOrEmpty(cep))
            {
                await Adicionar(obj);
            }
            
            return obj;
        }

        public async Task<CEP> Adicionar(CEP cep)
        {
            while (cep.cep.Length != 9)
            {
                throw new Exception("CEP Invalido");
            }

            try
            {
                await _cepRepository.AdicionarCep(cep);
            }
            catch (Exception ex)
            {

                throw new Exception(ex + "Aconteceu um erro");
            }

            return cep;


        }

        public async Task<List<CEP>> Listar()
        {
            List<CEP> ceps = await _cepRepository.ListarCeps();

            return ceps;
        }
    }
}
