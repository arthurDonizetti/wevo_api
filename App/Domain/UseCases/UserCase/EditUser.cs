using System.Threading.Tasks;
using App.Domain.Models.User;

namespace App.Domain.UseCases.UserCase
{
  public interface EditUser
  {
    Task<User> Edit(User user);
  }
}
