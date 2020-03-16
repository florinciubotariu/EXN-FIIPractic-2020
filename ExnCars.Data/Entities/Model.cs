using System.Collections.Generic;

namespace ExnCars.Data.Entities
{
  public class Model
  {
    public Model()
    {
      Vehicles = new List<Vehicle>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int ModelYear { get; set; }
    public string EngineCode { get; set; }
    public int EngineDisplacement { get; set; }

    public Brand Brand { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
  }
}
