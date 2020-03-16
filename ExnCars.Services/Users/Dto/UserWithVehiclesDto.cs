using System.Collections.Generic;

namespace ExnCars.Services.Users.Dto
{
  public class UserWithVehiclesDto
  {
    public UserWithVehiclesDto()
    {
      Vehicles = new List<VehicleDataDto>();
    }

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public IList<VehicleDataDto> Vehicles { get; set; }
  }

  public class VehicleDataDto
  {
    public int Id { get; set; }
    public string VIN { get; set; }
  }
}
