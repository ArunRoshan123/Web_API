using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModels
{
    public class RegisterModel
    {  
        public string fName { get; set; }
        public string lName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
    }
}
