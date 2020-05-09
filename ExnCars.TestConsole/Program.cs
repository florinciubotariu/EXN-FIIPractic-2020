using ExnCars.Data;
using ExnCars.Data.Entities;
using ExnCars.Services.Vehicles;
using System;
using Microsoft.Extensions.DependencyInjection;
using ExnCars.Services.Users;

namespace ExnCars.TestConsole
{
  class Program
  {
    static void Main(string[] args)
    {

      ServiceProvider serviceProvider = new ServiceCollection()
        .AddDbContext<ExnCarsContext>()
        .AddTransient(typeof(IRepository<>), typeof(Repository<>))
        .AddTransient<IUnitOfWork, UnitOfWork>()
        .AddScoped<IVehicleService, VehicleService>()
        .AddTransient<IUserService, UserService>()
        .BuildServiceProvider();

      IVehicleService vehicleService;
      
      //Context 1
      using (var scope = serviceProvider.CreateScope())
      {
        vehicleService = scope.ServiceProvider.GetService<IVehicleService>();

        var allVehicles = vehicleService.GetAll();

        foreach (var vehicle in allVehicles)
        {
          Console.WriteLine($"[{vehicle.Id}] - {vehicle.ExteriorColor} - {vehicle.BrandName} {vehicle.ModelName} - {vehicle.VIN}");
        }
        vehicleService.ListInstanceCount();
      }

      Console.WriteLine("All done!");
    }
  }
}
