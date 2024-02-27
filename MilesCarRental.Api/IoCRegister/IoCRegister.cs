using Microsoft.EntityFrameworkCore;
using MilesCarRental.Application.Services;
using MilesCarRental.Application.Services.Interfaces;
using MilesCarRental.Domain.IRepository;
using MilesCarRental.Domain.IServices;
using MilesCarRental.Domain.UseCase;
using MilesCarRental.Infrastructure;
using MilesCarRental.Infrastructure.Repository;

namespace MilesCarRental.Api.IoCRegister
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services, string conectionString = "")
        {
            AddRegisterDBContext(services, conectionString);
            AddRegisterRepositories(services);
            AddRegisterServices(services);
            return services;
        }

        private static void AddRegisterDBContext(this IServiceCollection services, string conectionString)
        {
            services.AddDbContext<CarRentalDbContext>(cfg =>
            {
                cfg.UseSqlServer(conectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IVehiculoServices, VehiculoServices>();
            services.AddTransient<IVehiculoServicesPort, VehiculoUseCase>();

            services.AddTransient<IAlquilerServices, AlquilerServices>();
            services.AddTransient<IAlquilerServicesPort, AlquilerUseCase>();

            return services;
        }

        private static void AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<IAlquilerRepository, AlquilerRepository>();
        }
    }
}
