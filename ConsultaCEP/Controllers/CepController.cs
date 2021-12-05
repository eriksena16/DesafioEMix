using AutoMapper;
using ConsultaCEP.Models;
using ConsultaCEP.Models.ViewModels;
using ConsultaCEP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCEP.Controllers
{
    public class CepController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICepService _cepService;
        public CepController(IMapper mapper, ICepService cepService)
        {
            _mapper = mapper;
            _cepService = cepService;
        }
        public async Task<ActionResult<IEnumerable<CepViewModel>>> ListarCeps()
        {
            var ceps = _mapper.Map<IEnumerable<CepViewModel>>(await _cepService.Listar());

            return View(ceps);
        }

        public async Task<IActionResult> ConsultaCep(string cep)
        {
            if (!String.IsNullOrEmpty(cep))
            {
               await _cepService.ConsultarCep(cep);
            }

            return RedirectToAction("ListarCeps");
        }
    }
}
