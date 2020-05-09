using ExnCars.Services.Vehicles.Dto;
using System.Collections.Generic;

namespace ExnCars.Services.Vehicles
{
    public interface IVehicleService
    {
        void AddVehicle(VehicleBasicInfoDto vehicle);
        VehicleBasicInfoDto GetById(int id);
        IList<VehicleDto> GetAll();
        void ListInstanceCount();
        void Delete(int id);
    }
}