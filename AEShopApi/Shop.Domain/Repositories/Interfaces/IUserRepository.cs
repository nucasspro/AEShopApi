﻿using Shop.Domain.Entities;
using Shop.Domain.SeedWork;

namespace Shop.Domain.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
        bool CheckUserExists(string username);
    }
}