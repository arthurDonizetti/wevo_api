using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Infra.Db.Repositories;
using App.Domain.Models.User;
using App.Domain.Interfaces;
using App.Infra.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace App.Tests.DbUser
{
  [TestClass]
  public class DbUserTest
  {
    private Data.UseCases.UserCase.DbUser dbUser;
    private IRepository<User> repository;
    private InMemoryContext Context;

    [TestInitialize]
    public void Initialize()
    {
      this.Context = new InMemoryContext(new InMemoryContextFactory().CreateOptionsBuilder().Options);
      this.Context.Database.EnsureCreated();

      this.repository = new InMemoryRepository<User>(Context);
      this.dbUser = new Data.UseCases.UserCase.DbUser(this.repository);
    }

    [TestCleanup]
    public void Cleanup()
    {
      this.Context.Dispose();
    }

    [TestMethod]
    public async Task TestUserCreation()
    {
      await this.dbUser.Add(new User
      {
        Nome = "any_name",
        Cpf = "12345678901",
        DataNascimento = DateTime.Today,
        Email = "any@email.com",
        Sexo = 'M',
        Telefone = "000000000"
      });

      var users = await this.dbUser.Select();
      List<User> lista = new List<User>(users);

      Assert.AreEqual(lista.Count, 1);
    }

    [TestMethod]
    public async Task TestUserUpdate()
    {
      var user = await this.dbUser.Add(new User
      {
        Nome = "any_name",
        Cpf = "12345678901",
        DataNascimento = DateTime.Today,
        Email = "any@email.com",
        Sexo = 'M',
        Telefone = "000000000"
      });

      user.Nome = "another_name";

      user = await this.dbUser.Edit(new User
      {
        Id = user.Id,
        Nome = "any_name",
        Cpf = "12345678901",
        DataNascimento = DateTime.Today,
        Email = "any@email.com",
        Sexo = 'M',
        Telefone = "000000000"
      });

      var changedUser = await this.dbUser.Select(user.Id);

      Assert.AreEqual(changedUser.Nome, user.Nome);
    }

    [TestMethod]
    public async Task TestUserDelete()
    {
      var user = await this.dbUser.Add(new User
      {
        Nome = "any_name",
        Cpf = "12345678901",
        DataNascimento = DateTime.Today,
        Email = "any@email.com",
        Sexo = 'M',
        Telefone = "000000000"
      });

      await this.dbUser.Delete(user.Id);

      var deletedUser = await this.dbUser.Select(user.Id);

      Assert.IsNull(deletedUser);
    }
  }
}
