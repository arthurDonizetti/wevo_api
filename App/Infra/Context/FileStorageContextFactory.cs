using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.Infra.Context
{
  public class FileStorageContextFactory : IDesignTimeDbContextFactory<FileStorageContext>
  {
    public FileStorageContext CreateDbContext(string[] args)
    {
      var optionBuilder = CreateOptionsBuilder();
      return new FileStorageContext(optionBuilder.Options);
    }

    public DbContextOptionsBuilder<FileStorageContext> CreateOptionsBuilder()
    {
      var connectionString = GetConnection();
      var optionBuilder = new DbContextOptionsBuilder<FileStorageContext>();

      var keepAliveConnection = new SqliteConnection(connectionString);
      keepAliveConnection.Open();

      optionBuilder.UseSqlite(keepAliveConnection);
      return optionBuilder;
    }

    public string GetConnection()
    {
      DotNetEnv.Env.TraversePath().Load();
      string db = System.Environment.GetEnvironmentVariable("MYSQL_DATABASE");

      return $@"Data Source={db}";
    }
  }
}
