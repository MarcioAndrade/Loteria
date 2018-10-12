using Repository.Context;
using Repository.Repository;
using Domain.LotoFacil.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<LoteriaContext>();
            services.AddScoped<ILotoFacilRepository, LotoFacilRepository>();
        }
    }
}
