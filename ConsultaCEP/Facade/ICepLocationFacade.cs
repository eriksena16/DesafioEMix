using ConsultaCEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCEP.Facade
{
   public interface ICepLocationFacade
    {
        Task<CEP> Get(string cep);
    }
}
