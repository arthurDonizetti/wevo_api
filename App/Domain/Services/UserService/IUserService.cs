using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Models.User;

namespace App.Domain.Services.UserService
{
  public interface IUserService
  {
    Task<User> Get(Guid Id);
    Task<IEnumerable<User>> GetAll();
    Task<User> Post(User user);
    Task<User> Put(User user);
    Task<bool> Delete(Guid Id);
  }
}
