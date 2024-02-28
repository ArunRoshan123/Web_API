using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModels
{
    public class ForgotPassword
    {
        public string userEmail { get; set; }
        public string userId { get; set; }
    }
}
