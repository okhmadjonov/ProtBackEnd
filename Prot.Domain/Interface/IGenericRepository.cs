﻿using Prot.Domain.Commons;
using System.Linq.Expressions;

namespace Prot.Domain.Interface;

public interface IGenericRepository<T> where T : Auditable
{
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true);
    ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracking = true, string[] includes = null);
    ValueTask<T> CreateAsync(T entity);
    ValueTask<bool> DeleteAsync(int id);
    T Update(T entity);
    ValueTask SaveChangesAsync();
}