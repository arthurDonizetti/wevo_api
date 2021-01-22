using System.Threading.Tasks;
using App.Domain.Interfaces;
using App.Domain.Models.User;

namespace App.Data.Protocols.Db.UserRepository
{
  public interface UserRepository : IRepository<User>
  {
  }
}
