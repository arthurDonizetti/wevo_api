using App.Domain.Models.User;
using App.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Context
{
  public class ApiContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<User>(new UserMap().Configure);
    }
  }
}
