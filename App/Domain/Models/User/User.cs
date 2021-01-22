using System;
namespace App.Domain.Models.User
{
  public class User : BaseModel
  {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public char Sexo { get; set; }
    public DateTime DataNascimento { get; set; }
  }
}
