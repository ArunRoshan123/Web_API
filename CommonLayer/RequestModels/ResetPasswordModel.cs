using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModels
{
    public class ResetPasswordModel
    {
        public string newPassword {  get; set; }
        public string confirmPassword { get; set; }
    }
}
