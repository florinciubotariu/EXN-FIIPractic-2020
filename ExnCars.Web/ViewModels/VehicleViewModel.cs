using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExnCars.Web.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string VIN { get; set; }
        public string ModelName { get; set; }
        public int ModelId { get; set; }
        public string BrandName { get; set; }
        public IFormFile Image { get; set; }
        public string PhotoUrl { get; set; }
    }
}
