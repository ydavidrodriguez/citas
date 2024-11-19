using AutoMapper;
using Citas.Application.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Citas.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());

            });
            services.AddSingleton(mapper.CreateMapper());

            return services;

        }

    }
}
