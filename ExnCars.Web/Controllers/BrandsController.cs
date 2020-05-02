using ExnCars.Services.Brands;
using ExnCars.Services.Brands.Dto;
using ExnCars.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ExnCars.Web.Controllers
{
  public class BrandsController : Controller
  {
    private readonly IBrandService brandService;
    public BrandsController(IBrandService brandService)
    {
      this.brandService = brandService;
    } 

    [HttpGet]
    [Route("brands/getall")]
    public IActionResult GetAllBrands()
    {
      var brands = brandService.GetBrands();
      return Json(brands);
    }

    [HttpGet]
    public IActionResult Index()
    {
      var brandDtos = brandService.GetBrands();

      var brandViewModels = brandDtos.Select(x => new BrandViewModel
      {
        Id = x.Id,
        Name = x.Name,
        LogoUrl = x.LogoUrl
      });

      return View(brandViewModels);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] BrandViewModel newBrand)
    {
      if (!ModelState.IsValid)
      {
        return View(newBrand);
      }
      var brandDto = new BrandDto
      {
        Name = newBrand.Name,
        LogoUrl = newBrand.LogoUrl
      };

      brandService.AddBrand(brandDto);

      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
      var brand = brandService.GetBrand(id);
      if (brand == null)
      {
        return RedirectToAction("Index");
      }

      var brandViewModel = new BrandViewModel
      {
        Id = brand.Id,
        Name = brand.Name,
        LogoUrl = brand.LogoUrl
      };

      return View(brandViewModel);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      var brand = brandService.GetBrand(id);
      if (brand == null)
      {
        return RedirectToAction("Index");
      }

      var brandViewModel = new BrandViewModel
      {
        Id = brand.Id,
        Name = brand.Name,
        LogoUrl = brand.LogoUrl
      };

      return View(brandViewModel);
    }

    [HttpPost]
    public IActionResult Edit([FromForm] BrandViewModel newBrandDetails)
    {
      var brand = brandService.GetBrand(newBrandDetails.Id);
      if (brand == null)
      {
        return RedirectToAction("Index");
      }

      brand.Name = newBrandDetails.Name;
      brand.LogoUrl = newBrandDetails.LogoUrl;

      brandService.UpdateBrand(brand);

      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      var brand = brandService.GetBrand(id);
      if (brand == null)
      {
        return RedirectToAction("Index");
      }

      var brandViewModel = new BrandViewModel
      {
        Id = brand.Id,
        Name = brand.Name,
        LogoUrl = brand.LogoUrl
      };

      return View(brandViewModel);
    }

    [HttpPost]
    public IActionResult ConfirmDelete([FromForm] int id)
    {
      brandService.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
