using System;
using System.Collections.Generic;

namespace ExnCars.Data.Entities
{
  public class Vehicle
  {
    public int Id { get; set; }
    public string VIN { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public string RegistrationNumber { get; set; }

    public int ModelId { get; set; }
    public Model Model { get; set; }
    public VehicleDetail VehicleDetail { get; set; }
    public ICollection<UserVehicles> UserVehicles { get; set; }
  }
}
