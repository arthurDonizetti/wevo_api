using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Connection
{
  public class ConnectionContext
  {
    private ConnectionStrategy _connectionStrategy;

    public ConnectionContext() { }

    public ConnectionContext(ConnectionStrategy connectionStrategy)
    {
      this._connectionStrategy = connectionStrategy;
    }

    public void SetStrategy(ConnectionStrategy connectionStrategy)
    {
      this._connectionStrategy = connectionStrategy;
    }

    public void StartConnection(IServiceCollection serviceCollection)
    {
      this._connectionStrategy.Connect(serviceCollection);
    }
  }
}
