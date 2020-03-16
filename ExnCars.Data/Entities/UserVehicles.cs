namespace ExnCars.Data.Entities
{
  public class UserVehicles
  {
    public int UserId { get; set; }
    public int VehicleId { get; set; }

    public Vehicle Vehicle { get; set; }
    public User User { get; set; }
  }
}
