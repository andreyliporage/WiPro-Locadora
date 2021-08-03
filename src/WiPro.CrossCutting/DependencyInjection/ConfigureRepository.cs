using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WiPro.Data.Context;
using WiPro.Data.Repository;
using WiPro.Domain.Interfaces;

namespace WiPro.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependeciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddDbContext<WiProContext>(opt => opt.UseInMemoryDatabase(databaseName: "MockDb"));
        }
    }
}