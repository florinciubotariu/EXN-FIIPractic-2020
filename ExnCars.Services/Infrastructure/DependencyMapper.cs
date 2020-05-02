using ExnCars.Data;
using ExnCars.Services.Brands;
using ExnCars.Services.Users;
using ExnCars.Services.Vehicles;
using Microsoft.Extensions.DependencyInjection;

namespace ExnCars.Services.Infrastructure
{
  public static class DependencyMapper
  {
    public static IServiceCollection MapDependencies(IServiceCollection serviceCollection)
    {
      serviceCollection.AddDbContext<ExnCarsContext>()
        .AddScoped(typeof(IRepository<>), typeof(Repository<>))
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped<IVehicleService, VehicleService>()
        .AddScoped<IUserService, UserService>()
        .AddScoped<IBrandService, BrandService>();

      return serviceCollection;
    }
  }
}
