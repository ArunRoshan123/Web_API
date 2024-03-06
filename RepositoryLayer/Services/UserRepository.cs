using CommonLayer.RequestModels;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using RepositoryLayer.Services;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace RepositoryLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly FunNoteContext context;
        private readonly IConfiguration config;

        Encryption encryption = new Encryption();
        public UserRepository(FunNoteContext context,IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }
       
        //Registeration
        public UserEntity UserRegisteration(RegisterModel model)
        {
            UserEntity entity = new UserEntity();
            entity.fName = model.fName;
            entity.lName = model.lName;
            entity.userEmail = model.userEmail;
            entity.userPassword = encryption.GenerateHashedPassword(model.userPassword);

            UserEntity user = context.UserTable.FirstOrDefault(x => x.userEmail == model.userEmail);
            if(user != null) 
            {
                throw new Exception("User already exist");
            }
            else
            {
                context.UserTable.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        // Login
        public string UserLogin(LoginModel model)
        {

            UserEntity user = context.UserTable.FirstOrDefault(x => x.userEmail == model.userEmail);

            if (user != null)
            {
                if (encryption.CheckPassword(model.userPassword , user.userPassword))
                {
                    string token = GenerateToken(user.userEmail, user.userId);
                    return token;
                   
                }
                else
                {
                    throw new Exception("Incorrect password");
                }
            }
            else
            {

                throw new Exception("Incorrect email");
            }
        }

        // JWT 
        public string GenerateToken(string userEmail, int userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("email",userEmail),
                new Claim("userId",userId.ToString())
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // ForgotPassword
        public string ForgotPassword(string email)
        {
            var user = context.UserTable.FirstOrDefault(a => a.userEmail == email);
            if (user != null)
            {
                var token = GenerateToken(user.userEmail, user.userId);
                return token;
            }
            else
            {
                return null;
            }
        }

        public bool CheckEmail(string userEmail)
        {
            return context.UserTable.Any(x => x.userEmail == userEmail);
        }
        public bool UResetPassword(string Email, ResetPasswordModel model)
        {
            UserEntity User = context.UserTable.ToList().Find(User => User.userEmail == Email);
            
            if(User != null)
            {
                User.userPassword = GenerateHashedPassword(model.newPassword);
               // User.ChangedAt = DateTime.Now;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GenerateHashedPassword(object confirmPassword)
        {
            throw new NotImplementedException();
        }

        // review
        public UserEntity EditName(int usersId, UpdateModel model)
        {
            var name = context.UserTable.FirstOrDefault(x => x.userId == usersId);
            if (name != null)
            {
                name.fName = model.fname;
                name.lName = model.lname;
                context.SaveChanges();
            }
            return name;
        }

        public List<UserEntity> SearchUser(string name)
        {
            return context.UserTable.Where(x => x.fName == name).ToList();
        }
        public int CountUser(int user) 
        {
            return context.UserTable.Count();
        }
    }
}
