using Microsoft.EntityFrameworkCore;

namespace ExnCars.Data
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ExnCarsContext _dbContext;

    public UnitOfWork(ExnCarsContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void Commit()
    {
      _dbContext.SaveChanges();
    }
  }
}
