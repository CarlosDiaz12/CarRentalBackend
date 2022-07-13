using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Data;
using CarRental.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarRental.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<CarRentalContext>();

            // automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // non-generic
            services.AddScoped<IInspectionRepository, InspectionRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            // generic
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
