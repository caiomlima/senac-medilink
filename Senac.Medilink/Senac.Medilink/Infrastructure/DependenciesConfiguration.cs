using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Senac.Medilink.Data;

namespace Senac.Medilink.Infrastructure
{
    public class DependenciesConfiguration
    {
        private IConfiguration Configuration { get; }

        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options
                .UseMySql(
                    configuration["MySqlConnectionString"],
                    new MySqlServerVersion(new Version(8, 0, 0)),
                    options => options.CommandTimeout(20)));
        }
    }
}
