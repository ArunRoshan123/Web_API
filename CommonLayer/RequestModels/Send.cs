using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace CommonLayer.RequestModels
{
    public class Send
    {
        public string SendMail(string ToEmail, string Token)
        {
            Console.WriteLine(Token);
            string FromEmail = "arunraksha234@gmail.com";
            MailMessage Message = new MailMessage(FromEmail, ToEmail);
            string MailBody = "Token generated: " + Token;
            Message.Subject = "Token generated for Forget Password";
            Message.Body = MailBody.ToString();
            Message.BodyEncoding = Encoding.UTF8;
            Message.IsBodyHtml = true;

            SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential credential = new NetworkCredential("arunraksha234@gmail.com", "tjzl tyak krld iukh");
            SmtpClient.EnableSsl = true;
            SmtpClient.UseDefaultCredentials = true;
            SmtpClient.Credentials = credential;
            SmtpClient.Send(Message);
            return ToEmail;
        }
    }
}