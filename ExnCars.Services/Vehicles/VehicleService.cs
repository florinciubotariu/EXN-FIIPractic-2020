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
                InteriorColor = v.VehicleDetail.interiorColor,
                PhotoUrl = v.PhotoUrl
            }).ToList();
        }

        public void AddVehicle(VehicleBasicInfoDto vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));

            var vehicleEntity = new Vehicle
            {
                VIN = vehicle.VIN,
                RegistrationDate = DateTime.Now,
                RegistrationNumber = vehicle.RegistrationNumber,
                ModelId = vehicle.ModelId,
                PhotoUrl = vehicle.PhotoUrl
            };

            _vehicleRepository.Add(vehicleEntity);
            _unitOfWork.Commit();
        }

        public void ListInstanceCount()
        {
            Console.WriteLine($"\nVehicle Service Instance Count: {InstanceCount}.");
        }

        public VehicleBasicInfoDto GetById(int id)
        {
            var entity = _vehicleRepository.GetById(id);

            return new VehicleBasicInfoDto
            {
                Id = entity.Id,
                RegistrationNumber = entity.RegistrationNumber,
                ModelId = entity.ModelId,
                PhotoUrl = entity.PhotoUrl
            };
        }

        public void Delete(int id)
        {
            if (id < 1) throw new ArgumentException(nameof(id));

            var vehicle = _vehicleRepository.GetById(id);
            if (vehicle == null) throw new Exception($"Brand with ID = {id} was not found!");

            _vehicleRepository.Delete(vehicle);
            _unitOfWork.Commit();
        }
    }
}
