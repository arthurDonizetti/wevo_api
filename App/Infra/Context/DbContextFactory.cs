using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.Infra.Context
{
  public class DbContextFactory : IDesignTimeDbContextFactory<ApiContext>
  {
    public ApiContext CreateDbContext(string[] args)
    {
      var optionBuilder = CreateOptionsBuilder();
      return new ApiContext(optionBuilder.Options);
    }

    public DbContextOptionsBuilder<ApiContext> CreateOptionsBuilder()
    {
      var connectionString = GetConnection();
      var optionBuilder = new DbContextOptionsBuilder<ApiContext>();
      optionBuilder.UseMySql(connectionString);
      return optionBuilder;
    }

    public string GetConnection()
    {
      DotNetEnv.Env.TraversePath().Load();

      string db = System.Environment.GetEnvironmentVariable("MYSQL_DATABASE");
      string user = System.Environment.GetEnvironmentVariable("MYSQL_USER");
      string password = System.Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD");
      string host = System.Environment.GetEnvironmentVariable("MYSQL_HOST");
      string port = System.Environment.GetEnvironmentVariable("MYSQL_PORT");

      return $@"Server={host};Port={port};Database={db};Uid={user};Pwd={password}";
    }
  }
}
