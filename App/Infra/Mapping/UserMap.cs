using App.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Mapping
{
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("user");
      builder.HasKey(user => user.Id);

      builder.Property(user => user.Nome)
          .IsRequired()
          .HasMaxLength(255);
      builder.Property(user => user.Email)
          .IsRequired()
          .HasMaxLength(255);
      builder.Property(user => user.Cpf)
          .IsRequired()
          .HasMaxLength(11);
      builder.Property(user => user.Sexo)
          .IsRequired()
          .HasMaxLength(1);
      builder.Property(user => user.Telefone)
          .IsRequired()
          .HasMaxLength(30);
    }
  }
}
