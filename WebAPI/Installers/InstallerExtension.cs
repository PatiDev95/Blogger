﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebAPI.Installers
{
    public static class InstallerExtension 
    {
        public static void InstallerServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
               typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
