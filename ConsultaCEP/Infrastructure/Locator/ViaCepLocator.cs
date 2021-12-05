using ConsultaCEP.AntiCorruption.Service;
using ConsultaCEP.Facade;
using ConsultaCEP.Repositories.Data;
using ConsultaCEP.Repositories.Interface;
using ConsultaCEP.Repositories.Service;
using ConsultaCEP.Services.Interface;
using ConsultaCEP.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultaCEP.Infrastructure.Locator
{
    public static class ViaCepLocator
    {
        public static void ConfigureViaCepService(this IServiceCollection services)
        {
            //REPOSITORIES
            services.AddScoped<DbContext, CepContext>();
            services.AddScoped<ICepRepository, CepRepository>();

            //SERVICES
            services.AddScoped<ICepService, CepService>();
            services.AddScoped<ICepLocationFacade, CepLocationService>();

            //HttpClient
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
