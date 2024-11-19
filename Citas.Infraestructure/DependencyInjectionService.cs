using Citas.Application;
using Citas.Domain.Services.Interfaces.Citas;
using Citas.Infraestructure.Database;
using Citas.Infraestructure.Repositories.Citas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Citas.Infraestructure
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(configuration["sqlconnectionstrings"]));

            services.AddScoped<IDataBaseService, DataBaseService>();
            services.AddScoped<ICitaRepository, CitaRepository>();
            //GetToken
            //services.AddTransient<IGettokenJwt, GetTokenJwtService.GetTokenJwtService>();

            return services;
        }


    }
}
