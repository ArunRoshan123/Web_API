using CommonLayer.RequestModels;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UserEntity = RepositoryLayer.Entity.UserEntity;
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
        public string ForgotPassword(string userEmail)
        {
            return repository.ForgotPassword(userEmail);
        }
        public string GenerateToken(string userEmail, int userId)
        {
            return repository.GenerateToken(userEmail, userId);
        }
        public bool UResetPassword(string Email, ResetPasswordModel model)
        {
            return repository.UResetPassword(Email, model);
        }
        public bool CheckEmail(string userEmail)
        {
            return repository.CheckEmail(userEmail);
        }

    }
}
