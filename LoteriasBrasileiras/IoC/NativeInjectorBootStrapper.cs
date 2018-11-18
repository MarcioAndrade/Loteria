using Repository.Context;
using Repository.Repository;
using Application.Interfaces;
using Domain.MegaSena.Repository;
using Domain.LotoFacil.Repository;
using Microsoft.Extensions.DependencyInjection;
using Application.ImportacaoResultado.MegaSena;
using Application.ImportacaoResultado.LotoFacil;

namespace IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<LoteriaContext>();

            //Repository
            services.AddScoped<ILotoFacilRepository, LotoFacilRepository>();
            services.AddScoped<IMegaSenaRepository, MegaSenaRepository>();

            //Services
            services.AddScoped<ILotoFacilAppService, ImportadorLotoFacil>();
            services.AddScoped<IMegaSenaAppService, ImportadorMegaSena>();
        }
    }
}
