using ExnCars.Services.Users.Dto;
using System.Collections.Generic;

namespace ExnCars.Services.Users
{
  public interface IUserService
  {
    IList<UserWithVehiclesDto> GetUserWithVehicles();
  }
}