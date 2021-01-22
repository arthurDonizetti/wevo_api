using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Protocols.Db.UserRepository;
using App.Data.UseCases.UserCase;
using App.Domain.Interfaces;
using App.Domain.Models;
using App.Domain.Models.User;
using App.Domain.Services.UserService;
using App.Infra.Connection;
using App.Infra.Db.Repositories;
using App.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      DotNetEnv.Env.TraversePath().Load();
      string enviromentVar = System.Environment.GetEnvironmentVariable("ENVIRONMENT");

      ConnectionContext context = new ConnectionContext();

      if (enviromentVar.ToLower() == "production")
      {
        context.SetStrategy(new DatabaseConnection());
        context.StartConnection(services);
        services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
      }
      else
      {
        context.SetStrategy(new StorageConnection());
        context.StartConnection(services);
        services.AddScoped(typeof(IRepository<>), typeof(FileStorageRepository<>));
      }

      services.AddTransient<IUserService, UserService>();
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
