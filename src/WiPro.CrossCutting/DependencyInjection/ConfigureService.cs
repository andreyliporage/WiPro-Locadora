using Microsoft.Extensions.DependencyInjection;
using WiPro.Domain.Interfaces;
using WiPro.Service.Services;

namespace WiPro.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependeciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IClienteService, ClienteService>();
            serviceCollection.AddTransient<IFilmeService, FilmeService>();
            serviceCollection.AddTransient<ILocacaoService, LocacaoService>();
        }
    }
}