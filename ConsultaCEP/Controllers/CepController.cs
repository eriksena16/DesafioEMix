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
        public async Task<ActionResult<IEnumerable<CepViewModel>>> ListarCeps(string uf, string cep)
        {

            var ceps = _mapper.Map<IEnumerable<CepViewModel>>(await _cepService.Listar());

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(uf))
                {
                    ceps = _mapper.Map<IEnumerable<CepViewModel>>(await _cepService.ListarToUF(uf.ToUpper()));

                    if (uf.Length != 2)
                    {
                        TempData["UfErro"] = "Digite uma UF válido, Ex: BA";

                        await Detalhes(cep);
                    }
                }

                if (TempData["CepError"] != null)
                    ModelState.AddModelError(string.Empty, TempData["CepError"].ToString());

                if (TempData["UfErro"] != null)
                    ModelState.AddModelError(string.Empty, TempData["UfErro"].ToString());

            }
            


            return View(ceps);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaCep(string cep)
        {
           

            if (!String.IsNullOrEmpty(cep))
            {
                if (cep.Length != 8 || HasSpecialChar(cep))
                {
                    TempData["CepError"] = "Digite um Cep válido, Ex: 40270450";

                    return RedirectToAction("ListarCeps");
                }

                var retorno = await _cepService.ConsultarCep(cep);

                if (retorno.cep is null)
                {
                    TempData["CepError"] = "CEP NÃO ENCONTRADO";

                    return RedirectToAction("ListarCeps");
                }

               await Detalhes(cep);
            }

            return View("Detalhes");
        }

        public async Task<IActionResult> Detalhes(string cep)
        {
            if (cep == null)
            {
                return NotFound();
            }

            var obj = _mapper.Map<CepViewModel>(await _cepService.DetalhesToCep(cep));

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public static bool HasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
    }
}
