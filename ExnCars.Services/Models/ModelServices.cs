using ExnCars.Data;
using ExnCars.Data.Entities;
using ExnCars.Services.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExnCars.Services.Models
{
    public class ModelServices : IModelService
    {
        private readonly IRepository<Model> _modelRepository;
        public ModelServices(IRepository<Model> modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public IEnumerable<VehicleModelDto> GetAllModels()
        {
            var entities = _modelRepository.GetAll();

            var dtoList = entities.Select(m => new VehicleModelDto
            {
                Id = m.Id,
                Name = m.Name
            });

            return dtoList;
        }

        public VehicleModelDto GetById(int id)
        {
            var entity = _modelRepository.GetById(id);

            return new VehicleModelDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
