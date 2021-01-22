using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Db.Repositories
{
  public class FileStorageRepository<T> : IRepository<T> where T : BaseModel
  {
    protected readonly FileStorageContext _context;
    private DbSet<T> _dataset;

    public FileStorageRepository(FileStorageContext context)
    {
      this._context = context;
      this._dataset = this._context.Set<T>();
    }

    public async Task<T> InsertAsync(T item)
    {
      try
      {
        if (item.Id == Guid.Empty)
          item.Id = Guid.NewGuid();

        item.CreateAt = DateTime.UtcNow;

        this._dataset.Add(item);

        await this._context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return item;
    }

    public async Task<T> UpdateAsync(T item)
    {
      try
      {
        var current = await this._dataset.SingleOrDefaultAsync(i => i.Id.Equals(item.Id));

        if (current == null)
          return null;

        this._context.Entry(current).CurrentValues.SetValues(item);
        await this._context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return item;
    }

    public async Task<bool> DeleteAsync(Guid Id)
    {
      try
      {
        var current = await this._dataset.SingleOrDefaultAsync(i => i.Id.Equals(Id));
        if (current == null)
          return false;

        this._dataset.Remove(current);
        await this._context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<T> SelectAsync(Guid Id)
    {
      try
      {
        return await this._dataset.SingleOrDefaultAsync(i => i.Id.Equals(Id));
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<IEnumerable<T>> SelectAsync()
    {
      try
      {
        return await this._dataset.ToListAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
