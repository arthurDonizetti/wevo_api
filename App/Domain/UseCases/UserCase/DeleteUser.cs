using System;
using System.Threading.Tasks;

namespace App.Domain.UseCases.UserCase
{
  public interface DeleteUser
  {
    Task<bool> Delete(Guid Id);
  }
}
