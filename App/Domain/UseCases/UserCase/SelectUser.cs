using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Models.User;

namespace App.Domain.UseCases.UserCase
{
  public interface SelectUser
  {
    Task<User> Select(Guid Ud);
    Task<IEnumerable<User>> Select();
  }
}
