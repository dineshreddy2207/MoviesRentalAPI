using Application.Mappers;
using Application.Services;
using Application.Validators;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using static Application.Validators.MovieValidator;

namespace Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Database
            services.AddDbContext<MovieRentalDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // AutoMapper
            services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

            // Repositories
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();

            // Services
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IRentalService, RentalService>();

            // FluentValidation
            services.AddValidatorsFromAssemblyContaining<MovieCreateValidator>();

            // Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}").CreateLogger();
            services.AddSerilog();

            return services;
        }
    }

}
