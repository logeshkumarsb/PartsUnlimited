using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PartsUnlimitedOperations;

namespace PartsUnlimitedWebAdaptors
{
    public class LogIn : HomePage,ILogIn
    {
        IWebDriver driver;
        public LogIn()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5001/");
            driver.Navigate().GoToUrl("http://localhost:5001/Account/Login");

        }
        public void ForgotPassword()
        {
            throw new NotImplementedException();
        }

        public void RegisterNewUser()
        {
            throw new NotImplementedException();
        }

        public bool RemeberMeChechBox()
        {
            throw new NotImplementedException();
        }

        void ILogIn.LogIn(string username, string password)
        {
             
        }
    }
}
