using System.Threading.Tasks;
using App.Domain.Models.User;

namespace App.Domain.UseCases.UserCase
{
  public interface AddUser
  {
    Task<User> Add(User user);
  }
}
