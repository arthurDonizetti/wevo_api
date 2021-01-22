using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Connection
{
  public interface ConnectionStrategy
  {
    void Connect(IServiceCollection serviceCollection);
  }
}
