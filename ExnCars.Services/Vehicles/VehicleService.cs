using ExnCars.Data;
using ExnCars.Data.Entities;
using ExnCars.Services.Vehicles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExnCars.Services.Vehicles
{
  public class VehicleService : IVehicleService
  {
    private static int InstanceCount = 0;

    private readonly IRepository<Vehicle> _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VehicleService(IRepository<Vehicle> vehicleRepo, IUnitOfWork unitOfWork)
    {
      InstanceCount++;
      _vehicleRepository = vehicleRepo;
      _unitOfWork = unitOfWork;
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

    public void AddVehicle(VehicleBasicInfoDto vehicle)
    {
      if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));

      var vehicleEntity = new Vehicle
      {
        VIN = vehicle.VIN,
        RegistrationDate = vehicle.RegistrationDate,
        RegistrationNumber = vehicle.RegistrationNumber,
        ModelId = vehicle.ModelId
      };

      _vehicleRepository.Add(vehicleEntity);
      _unitOfWork.Commit();
    }

    public void ListInstanceCount()
    {
      Console.WriteLine($"\nVehicle Service Instance Count: {InstanceCount}.");
    }
  }
}
