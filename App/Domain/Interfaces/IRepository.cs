using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Models;

namespace App.Domain.Interfaces
{
  public interface IRepository<T> where T : BaseModel
  {
    Task<T> InsertAsync(T item);
    Task<T> UpdateAsync(T item);
    Task<bool> DeleteAsync(Guid Id);
    Task<T> SelectAsync(Guid Id);
    Task<IEnumerable<T>> SelectAsync();
  }
}
