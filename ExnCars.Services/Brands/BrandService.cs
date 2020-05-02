using ExnCars.Data;
using ExnCars.Data.Entities;
using ExnCars.Services.Brands.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExnCars.Services.Brands
{
  public class BrandService : IBrandService
  {
    private readonly IRepository<Brand> brandRepository;
    private readonly IUnitOfWork unitOfWork;

    public BrandService(IRepository<Brand> brandRepository, IUnitOfWork unitOfWork)
    {
      this.brandRepository = brandRepository;
      this.unitOfWork = unitOfWork;
    }

    public List<BrandDto> GetBrands()
    {
      var brands = brandRepository.GetAll();

      var brandDtos = new List<BrandDto>();

      foreach (var brand in brands)
      {
        var brandDto = new BrandDto
        {
          Id = brand.Id,
          Name = brand.Name,
          LogoUrl = brand.LogoUrl
        };

        brandDtos.Add(brandDto);
      }

      return brandDtos;

      //return brands.Select(x => new BrandDto
      //{
      //  Id = x.Id,
      //  Name = x.Name,
      //  LogoUrl = x.LogoUrl
      //}).ToList();
    }

    public BrandDto GetBrand(int id)
    {
      if (id < 1) throw new ArgumentException(nameof(id));

      var brand = brandRepository.GetById(id);
      if (brand == null) return null;

      var brandDto = new BrandDto
      {
        Id = brand.Id,
        Name = brand.Name,
        LogoUrl = brand.LogoUrl
      };

      return brandDto;
    }

    public void AddBrand(BrandDto brandDto)
    {
      if (brandDto == null) throw new ArgumentNullException(nameof(brandDto));

      var brand = new Brand
      {
        Name = brandDto.Name,
        LogoUrl = brandDto.LogoUrl
      };

      brandRepository.Add(brand);

      unitOfWork.Commit();
    }

    public void UpdateBrand(BrandDto brandDto)
    {
      if (brandDto == null) throw new ArgumentNullException(nameof(brandDto));

      var brand = brandRepository.GetById(brandDto.Id);
      if (brand == null) throw new Exception($"Brand with ID = {brandDto.Id} was not found!");

      brand.Name = brandDto.Name;
      brand.LogoUrl = brandDto.LogoUrl;

      brandRepository.Update(brand);
      unitOfWork.Commit();
    }

    public void Delete(int id)
    {
      if (id < 1) throw new ArgumentException(nameof(id));

      var brand = brandRepository.GetById(id);
      if (brand == null) throw new Exception($"Brand with ID = {id} was not found!");

      brandRepository.Delete(brand);
      unitOfWork.Commit();
    }
  }
}
