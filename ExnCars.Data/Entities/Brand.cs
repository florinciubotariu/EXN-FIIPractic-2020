using System;
using System.Collections.Generic;
using System.Text;

namespace ExnCars.Data.Entities
{
  public class Brand
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }

    public ICollection<Model> Models { get; set; }
  }
}
