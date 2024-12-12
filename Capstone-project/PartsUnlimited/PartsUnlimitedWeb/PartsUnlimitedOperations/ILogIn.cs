using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimitedOperations
{
    public interface ILogIn
    {
        public bool LogIn();
        public bool GetUserName();
        public bool GetPassword();
        public bool LogInButton();
        public bool RemeberMeChechBox();
        public bool RegisterNewUser();
        public bool ForgotPassword();
        
    }
}
