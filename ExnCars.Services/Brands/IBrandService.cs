using ExnCars.Services.Brands.Dto;
using System.Collections.Generic;

namespace ExnCars.Services.Brands
{
  public interface IBrandService
  {
    void AddBrand(BrandDto brandDto);
    void Delete(int id);
    BrandDto GetBrand(int id);
    List<BrandDto> GetBrands();
    void UpdateBrand(BrandDto brandDto);
  }
}
