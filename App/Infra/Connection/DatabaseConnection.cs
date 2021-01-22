using System.Data.Common;
using App.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Connection
{
  public class DatabaseConnection : ConnectionStrategy
  {
    public void Connect(IServiceCollection serviceCollection)
    {
      serviceCollection.AddDbContext<ApiContext>(options =>
        options.UseMySql(new DbContextFactory().GetConnection()));
    }
  }
}
