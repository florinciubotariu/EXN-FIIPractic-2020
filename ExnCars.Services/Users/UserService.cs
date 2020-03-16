using ExnCars.Data;
using ExnCars.Services.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExnCars.Services.Users
{
  public class UserService
  {
    private readonly ExnCarsContext _exnCarsContext;

    public UserService(ExnCarsContext exnCarsContext)
    {
      _exnCarsContext = exnCarsContext;
    }

    public IList<UserWithVehiclesDto> GetUserWithVehicles()
    {
      return _exnCarsContext.Users.Select(u => new UserWithVehiclesDto
      {
        Id = u.Id,
        FullName = $"{u.FirstName} {u.LastName}",
        Email = u.Email,
        Vehicles = u.UserVehicles.Select(uv => uv.Vehicle).Select(v => new VehicleDataDto
        {
          Id = v.Id,
          VIN = v.VIN
        }).ToList()
      }).ToList();
    }

    //public IList<UserWithVehiclesDto> GetUserWithVehicles_BAD()
    //{
    //  var users = _exnCarsContext.Users.Include(u => u.UserVehicles).ToList();

    //  var usersDtos = new List<UserWithVehiclesDto>();
    //  foreach (var user in users)
    //  {
    //    var userDto = new UserWithVehiclesDto
    //    {
    //      Id = user.Id,
    //      FullName = $"{user.FirstName} {user.LastName}",
    //      Email = user.Email
    //    };

    //    foreach(var userVehicle in user.UserVehicles)
    //    {
    //      var vehicle = _exnCarsContext.Vehicles.FirstOrDefault(x => x.Id == userVehicle.VehicleId);
    //      userDto.Vehicles.Add(new VehicleDataDto
    //      {
    //        Id = vehicle.Id,
    //        VIN = vehicle.VIN
    //      });
    //    }

    //    usersDtos.Add(userDto);
    //  }

    //  return usersDtos;
    //}
  }
}
