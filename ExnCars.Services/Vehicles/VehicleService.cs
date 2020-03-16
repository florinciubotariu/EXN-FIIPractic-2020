using ExnCars.Data;
using ExnCars.Data.Entities;
using ExnCars.Services.Vehicles.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ExnCars.Services.Vehicles
{
  public class VehicleService
  {
    private readonly IRepository<Vehicle> _vehicleRepository;

    public VehicleService(IRepository<Vehicle> vehicleRepo)
    {
      _vehicleRepository = vehicleRepo;
    }

    public IList<VehicleDto> GetAll()
    {
      return _vehicleRepository.Query().Select(v => new VehicleDto
      {
        Id = v.Id,
        VIN = v.VIN,
        RegistrationDate = v.RegistrationDate,
        RegistrationNumber = v.RegistrationNumber,
        ModelName = v.Model.Name,
        BrandName = v.Model.Brand.Name,
        ExteriorColor = v.VehicleDetail.ExteriorColor,
        InteriorColor = v.VehicleDetail.interiorColor
      }).ToList();
    }
  }
}
