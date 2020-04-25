using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExnCars.Data
{
  public class Repository<T> : IRepository<T>
    where T : class
  {
    private readonly ExnCarsContext _exnCarsContext;
    private readonly DbSet<T> _dbSet;

    public Repository(ExnCarsContext exnCarsContext)
    {
      _exnCarsContext = exnCarsContext;
      _dbSet = exnCarsContext.Set<T>();
    }

    public void Add(T entity)
    {
      _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
      _dbSet.Remove(entity);
    }

    public void Delete(IEnumerable<T> entities)
    {
      _dbSet.RemoveRange(entities);
    }

    public List<T> GetAll()
    {
      return _dbSet.ToList();
    }

    public T GetById(int id)
    {
      return _dbSet.Find(id);
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> expression)
    {
      return _dbSet.Where(expression).AsQueryable();
    }

    public IQueryable<T> Query()
    {
      return _dbSet.AsQueryable();
    }

    public void Update(T entity)
    {
      _dbSet.Attach(entity);
      _exnCarsContext.Entry(entity).State = EntityState.Modified;
    }
  }
}
