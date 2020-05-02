using System.ComponentModel.DataAnnotations;

namespace ExnCars.Web.ViewModels
{
  public class BrandViewModel
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is mandatory. Please insert it.")]
    public string Name { get; set; }
    [MinLength(3, ErrorMessage = "Logo url is too short. Minimum 3 characters")]
    [Required(ErrorMessage = "Logo url is mandatory. Please insert it.")]
    public string LogoUrl { get; set; }
  }
}
