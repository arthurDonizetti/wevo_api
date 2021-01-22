using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.Infra.Context
{
  public class InMemoryContextFactory : IDesignTimeDbContextFactory<InMemoryContext>
  {
    public InMemoryContext CreateDbContext(string[] args)
    {
      var optionBuilder = CreateOptionsBuilder();
      return new InMemoryContext(optionBuilder.Options);
    }

    public DbContextOptionsBuilder<InMemoryContext> CreateOptionsBuilder()
    {
      var connectionString = GetConnection();
      var optionBuilder = new DbContextOptionsBuilder<InMemoryContext>();

      var keepAliveConnection = new SqliteConnection(connectionString);
      keepAliveConnection.Open();

      optionBuilder.UseSqlite(keepAliveConnection);
      return optionBuilder;
    }

    private string GetConnection()
    {
      return $@"Data Source=:memory:";
    }
  }
}
