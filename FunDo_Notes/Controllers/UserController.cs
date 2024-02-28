using CommonLayer.RequestModels;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunDo_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly FunNoteContext context1;
        private readonly IBus bus;
        public UserController(IUserManager userManager,FunNoteContext context1,IBus bus)
        {
            this.userManager = userManager;
            this.context1 = context1;
            this.bus = bus;
        }
        [HttpPost]
        [Route("Reg")]
        public ActionResult Register(RegisterModel model)
        {
            try
            {
                var response = userManager.UserRegisteration(model);
                if (response != null)
                {
                    return Ok(new ResModel<UserEntity> { Success = true, Message = "register successfull", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<UserEntity> { Success = false, Message = "register failed", Data = response });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ResModel<UserEntity> { Success = false, Message = e.Message, Data = null });
            }
        }

        [HttpPost]
        [Route("Log")]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                string response = userManager.UserLogin(model);
                if (response != null)
                {
                    return Ok(new ResModel<string> { Success = true, Message = "Login sucessfull", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<string> { Success = false, Message = "Login failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string Email)
        {
            try
            {
                if(userManager.CheckEmail(Email))
                {
                    Send send = new Send();
                    string check = userManager.ForgotPassword(Email);
                    var checkmail = context1.UserTable.FirstOrDefault(x => x.userEmail == Email);
                    string token = userManager.GenerateToken(Email,checkmail.userId);
                    //var token = userManager.GenerateToken(checkmail.userEmail, checkmail.userId);
                    send.SendMail(Email, token);
                    Uri uri = new Uri("rabbitmq://localhost/Queue");
                    var endPoint = await bus.GetSendEndpoint(uri);

                    await endPoint.Send(token);

                    return Ok(new ResModel<string> { Success = true, Message = "mail sent", Data = token });
                }
                else
                {
                    return BadRequest(new ResModel<string> { Success = false, Message= "Email Does Not Exist", Data = null});
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        [HttpPost]
        [Authorize]
        [Route("ResetPassword")]
        public ActionResult ResetPassword(ResetPasswordModel reset)
        {

            string Email = User.FindFirst("Email").Value;
            if (userManager.UResetPassword(Email, reset))
            {
                return Ok(new ResModel<bool> { Success = true, Message = "Password changed", Data = true });
            }
            else
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = "Password is not changed", Data = false });

            }

        }
    }
    
}
