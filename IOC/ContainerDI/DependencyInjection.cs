using Data.Context;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.ConteinerDI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(MyContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductReposiroty, ProductRepository>();
            return services;
        }
    }
}
