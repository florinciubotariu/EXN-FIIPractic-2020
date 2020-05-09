using ExnCars.Data;
using ExnCars.Services.Azure;
using ExnCars.Services.Brands;
using ExnCars.Services.Models;
using ExnCars.Services.Users;
using ExnCars.Services.Vehicles;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExnCars.Services.Infrastructure
{
    public static class DependencyMapper
    {
        public static IServiceCollection MapDependencies(IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.AddDbContext<ExnCarsContext>(options => options.UseSqlServer(config["connectionString"]))
              .AddScoped(typeof(IRepository<>), typeof(Repository<>))
              .AddScoped<IUnitOfWork, UnitOfWork>()
              .AddScoped<IVehicleService, VehicleService>()
              .AddScoped<IUserService, UserService>()
              .AddScoped<IBrandService, BrandService>()
              .AddScoped<IModelService, ModelServices>()
              .AddScoped<IAzureService, AzureService>();

            return serviceCollection;
        }
    }
}
