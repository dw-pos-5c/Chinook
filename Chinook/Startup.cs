using ChinookDbLib;
using ChinookMVVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook
{
    internal class Startup
    {
        internal void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            string connectionString = configuration.GetConnectionString("ChinookDb");
            services.AddDbContext<ChinookContext>(x => x.UseSqlServer(connectionString));
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ChinookViewModel>();
            services.AddTransient<AnotherWindow>();
        }
    }
}
