using Repository.Context;
using Repository.Repository;
using Application.Interfaces;
using Domain.LotoFacil.Repository;
using Microsoft.Extensions.DependencyInjection;
using Application.ImportacaoResultado.LotoFacil;

namespace IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<LoteriaContext>();

            services.AddScoped<ILotoFacilRepository, LotoFacilRepository>();
            services.AddScoped<ILotoFacilAppService, ImportadorLotoFacil>();
        }
    }
}
