using System.Data.Common;
using App.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Connection
{
  public class StorageConnection : ConnectionStrategy
  {
    public void Connect(IServiceCollection serviceCollection)
    {
      serviceCollection.AddDbContextPool<FileStorageContext>(options =>
        options.UseSqlite(new FileStorageContextFactory().GetConnection()));
    }
  }
}
