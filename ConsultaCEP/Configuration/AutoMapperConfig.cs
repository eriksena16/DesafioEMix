using AutoMapper;
using ConsultaCEP.Models;
using ConsultaCEP.Models.ViewModels;

namespace ConsultaCEP.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CEP, CepViewModel>().ReverseMap();
        }
    }
}
