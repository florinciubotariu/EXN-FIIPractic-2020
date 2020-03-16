using System.Collections.Generic;

namespace ExnCars.Data.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Avatar { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<UserVehicles> UserVehicles { get; set; }
  }
}
