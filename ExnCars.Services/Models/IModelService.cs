using ExnCars.Services.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExnCars.Services.Models
{
    public interface IModelService
    {
        IEnumerable<VehicleModelDto> GetAllModels();

        VehicleModelDto GetById(int id);
    }
}
