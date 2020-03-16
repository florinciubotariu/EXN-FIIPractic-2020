using ExnCars.Data;
using ExnCars.Data.Entities;
using ExnCars.Services.Users;
using ExnCars.Services.Users.Dto;
using ExnCars.Services.Vehicles;
using System;
using System.Collections.Generic;

namespace ExnCars.TestConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      var context = new ExnCarsContext();
      var vehicleRepo = new Repository<Vehicle>(context);
      var vehicleService = new VehicleService(vehicleRepo);
      var allVehicles = vehicleService.GetAll();

      foreach (var vehicle in allVehicles)
      {
        Console.WriteLine($"[{vehicle.Id}] - {vehicle.ExteriorColor} - {vehicle.BrandName} {vehicle.ModelName} - {vehicle.VIN}");
      }

      //var userService = new UserService(context);
      //var userWithVehicles = userService.GetUserWithVehicles();
      //PrintUserWithVehicles(userWithVehicles);

      //var userWithVehicles_bad = userService.GetUserWithVehicles_BAD();
      //PrintUserWithVehicles(userWithVehicles_bad);

      Console.WriteLine("All done!");
    }

    private static void PrintUserWithVehicles(IList<UserWithVehiclesDto> userWithVehicles)
    {
      foreach (var user in userWithVehicles)
      {
        Console.WriteLine($"{user.FullName} has the following vehicles:");
        foreach (var vehicle in user.Vehicles)
        {
          Console.WriteLine($"[{vehicle.Id}] {vehicle.VIN}");
        }
      }
    }
  }
}
