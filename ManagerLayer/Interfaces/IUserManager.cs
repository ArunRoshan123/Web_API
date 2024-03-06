using CommonLayer.RequestModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface IUserManager
    {
        public UserEntity UserRegisteration(RegisterModel model);
        public string UserLogin(LoginModel model);

        public string ForgotPassword(string userEmail);

        public bool CheckEmail(string  userEmail);

        public string GenerateToken(string userEmail, int userId);

        public bool UResetPassword(string Email, ResetPasswordModel model);
        public UserEntity EditName(int usersId, UpdateModel model);
        public List<UserEntity> SearchUser(string name);
        public int CountUser(int user);
    }

}
