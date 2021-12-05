using ConsultaCEP.Facade;
using ConsultaCEP.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsultaCEP.AntiCorruption.Service
{
    public class CepLocationService : ICepLocationFacade
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ViaCepOptions _viaCepOptions;

        public CepLocationService(IHttpClientFactory httpClientFactory, IOptionsMonitor<ViaCepOptions> viaCepOptions)
        {
            _httpClientFactory = httpClientFactory;
            _viaCepOptions = viaCepOptions.CurrentValue;
        }

        public async Task<CEP> Get(string cep)
        {
            string requestUri = string.Format(_viaCepOptions.RequestUriCep, cep);
            HttpClient httpClient = _httpClientFactory.CreateClient(ViaCepOptions.Instance);
            httpClient.BaseAddress = new Uri(_viaCepOptions.BaseAddress);
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestUri);
            string jsonContent = await httpResponseMessage.Content.ReadAsStringAsync();

            CEP retorno = JsonConvert.DeserializeObject<CEP>(jsonContent);

            return await Task.FromResult(retorno);
        }
    }
}
