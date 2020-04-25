using System;

namespace ExnCars.Services.Vehicles.Dto
{
  public class VehicleBasicInfoDto
  {
    public int Id { get; set; }
    public string VIN { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public string RegistrationNumber { get; set; }
    public int ModelId { get; set; }
  }
}
