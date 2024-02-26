using CommonLayer.RequestModels;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ManagerLayer.Services
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public UserEntity UserRegisteration(RegisterModel model)
        {
            return repository.UserRegisteration(model);
        }
        public string UserLogin(LoginModel model)
        {
            return repository.UserLogin(model);
        }
    }
}
