using Application;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Instalers
{
    public class MvcInstaler : IInstaller
    {
        public void InstallServices(IServiceCollection services,IConfiguration Configuration)
        {
            services.AddApplication();
            services.AddInfrastructure();
            
            services.AddControllers();
        }
    }
}
