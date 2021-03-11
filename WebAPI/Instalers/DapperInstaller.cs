using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace WebAPI.Instalers
{
    public class DapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            // Inject IDbConnection, with implementation from SqlConnection class.
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(Configuration.GetConnectionString("BloggerSC")));
        }
    }
}
