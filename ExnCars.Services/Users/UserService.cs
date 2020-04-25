using ExnCars.Data;
using ExnCars.Services.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExnCars.Services.Users
{
  public class UserService : IUserService
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


  }
}
