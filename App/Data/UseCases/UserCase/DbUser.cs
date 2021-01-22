using System.Threading.Tasks;
using App.Domain.UseCases.UserCase;
using App.Domain.Models.User;
using System.Collections.Generic;
using App.Data.Protocols.Db.UserRepository;
using App.Domain.Interfaces;
using System;

namespace App.Data.UseCases.UserCase
{
  public class DbUser : AddUser, EditUser, DeleteUser, SelectUser
  {
    private IRepository<User> _userRepository;

    public DbUser(IRepository<User> _userRepository)
    {
      this._userRepository = _userRepository;
    }

    public async Task<User> Add(User user)
    {
      return await this._userRepository.InsertAsync(user);
    }

    public async Task<User> Edit(User user)
    {
      return await this._userRepository.UpdateAsync(user);
    }

    public async Task<bool> Delete(Guid Id)
    {
      return await this._userRepository.DeleteAsync(Id);
    }

    public async Task<User> Select(Guid Id)
    {
      return await this._userRepository.SelectAsync(Id);
    }

    public async Task<IEnumerable<User>> Select()
    {
      return await this._userRepository.SelectAsync();
    }
  }
}
