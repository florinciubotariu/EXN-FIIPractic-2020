using System;
namespace ExnCars.Services.Vehicles.Dto
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string PhotoUrl { get; set; }
    }
}
