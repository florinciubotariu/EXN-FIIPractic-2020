﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExnCars.Data
{
  public interface IRepository<T> 
    where T : class
  {
    void Add(T entity);
    void Update(T entity);
    List<T> GetAll();
    void Delete(T entity);
    void Delete(IEnumerable<T> entities);
    IQueryable<T> Query(Expression<Func<T, bool>> expression);
    IQueryable<T> Query();
    T GetById(int id);
  }

}
