using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExnCars.Data.Entities
{
  public class VehicleDetail
  {
    [Key]
    public int VehicleId { get; set; }
    public string ExteriorColor { get; set; }
    public string interiorColor { get; set; }
    public DateTime? LastMotDate { get; set; }

    public Vehicle Vehicle { get; set; }
  }
}
