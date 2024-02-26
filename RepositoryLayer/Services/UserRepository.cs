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

        private string GenerateToken(string Email, long userId)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("email",Email),
                new Claim("userId",userId.ToString())
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(15),
                signingCredentials: signingCredentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
