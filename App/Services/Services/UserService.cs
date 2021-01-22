using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Interfaces;
using App.Domain.Models.User;
using App.Domain.Services.UserService;

namespace App.Services.Services
{
  public class UserService : IUserService
  {
    private IRepository<User> _repository;

    public UserService(IRepository<User> repository)
    {
      _repository = repository;
    }
    public async Task<bool> Delete(Guid Id)
    {
      return await this._repository.DeleteAsync(Id);
    }

    public async Task<User> Get(Guid Id)
    {
      return await this._repository.SelectAsync(Id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
      return await this._repository.SelectAsync();
    }

    public async Task<User> Post(User user)
    {
      return await this._repository.InsertAsync(user);
    }

    public async Task<User> Put(User user)
    {
      return await this._repository.UpdateAsync(user);
    }
  }
}
