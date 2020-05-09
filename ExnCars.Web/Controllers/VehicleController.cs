using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExnCars.Services.Azure;
using ExnCars.Services.Brands;
using ExnCars.Services.Models;
using ExnCars.Services.Vehicles;
using ExnCars.Services.Vehicles.Dto;
using ExnCars.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExnCars.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IModelService _modelService;
        private readonly IAzureService _azureService;


        public VehicleController(IVehicleService vehicleService, IAzureService azureService, IModelService modelService)
        {
            _vehicleService = vehicleService;
            _modelService = modelService;
            _azureService = azureService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vehicleDtos = _vehicleService.GetAll();

            var vehicleModel = vehicleDtos.Select(v => new VehicleViewModel
            {
                Id = v.Id,
                BrandName = v.BrandName,
                ModelName = v.ModelName,
                RegistrationNumber = v.RegistrationNumber,
                PhotoUrl = v.PhotoUrl
            });

            return View(vehicleModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Test = _modelService.GetAllModels();
            return View();
        }


        [HttpPost]
        public IActionResult Create([FromForm] VehicleViewModel model)
        {
            var vehicleDto = new VehicleBasicInfoDto();

            vehicleDto.VIN = model.VIN;
            vehicleDto.ModelId = model.ModelId;
            vehicleDto.RegistrationNumber = model.RegistrationNumber;


            if (model.Image != null)
            {
                using var stream = model.Image.OpenReadStream();
                var result = _azureService.Upload(ContainerType.VehiclePhoto ,stream, model.RegistrationNumber);
                vehicleDto.PhotoUrl = result.FullPath;
            }
            _azureService.PushMessageIntoQueue(model.RegistrationNumber);
            _vehicleService.AddVehicle(vehicleDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle == null)
            {
                return RedirectToAction("Index");
            }

            return View(new VehicleViewModel
            {
                Id = vehicle.Id,
                RegistrationNumber = vehicle.RegistrationNumber,
                ModelName = _modelService.GetById(vehicle.ModelId).Name
            });
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromForm] int id)
        {
            var vehicle = _vehicleService.GetById(id);
            _azureService.Delete(vehicle.PhotoUrl);
            _vehicleService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}