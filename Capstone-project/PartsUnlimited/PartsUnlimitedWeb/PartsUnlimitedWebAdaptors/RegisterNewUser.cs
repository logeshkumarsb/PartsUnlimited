using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PartsUnlimitedOperations;

namespace PartsUnlimitedWebAdaptors
{
    /// <summary>
    /// Class implementing the registration functionality for a new user.
    /// </summary>
    public class RegisterNewUser : PartsUnlimitedCommon, IRegisterNewUser
    {
        /// <summary>
        /// Creates a new user account by navigating to the registration page and filling out the required fields.
        /// </summary>
        /// <param name="UserName">The username for the new account.</param>
        /// <param name="Password">The password for the new account.</param>
        /// <returns>A confirmation message indicating the result of the account creation.</returns>
        public string CreateAccount(string UserName, string Password,String ConfirmPassword)
        {
            IWebElement LogIn = driver.FindElement(By.XPath("//a[@id='login-link']"));
            LogIn.Click();
            IWebElement navigate = driver.FindElement(By.XPath("//a[normalize-space()='Register as a new user']"));
            navigate.Click();
            Thread.Sleep(3000); // Temporary pause for navigation.
            IWebElement UserNameField = driver.FindElement(By.XPath("//input[@id='Email']"));
            UserNameField.SendKeys(UserName);
            IWebElement PasswordField = driver.FindElement(By.XPath("//input[@id='Password']"));
            PasswordField.SendKeys(Password);
            IWebElement ConfirmPasswordField = driver.FindElement(By.XPath("//input[@id='ConfirmPassword']"));
            ConfirmPasswordField.SendKeys(ConfirmPassword);
            IWebElement RegisterButton = driver.FindElement(By.XPath("//input[@value='Register']"));
            RegisterButton.Click();
            try
            {
                IWebElement Confirmation = driver.FindElement(By.XPath("//h2[normalize-space()='Demo link display page - Not for production use']"));
                return Confirmation.Text;
            }
            catch (Exception ex)
            {
                IWebElement ExistingAccount = driver.FindElement(By.XPath("//h4[normalize-space()='Create a new account.']"));
                return ExistingAccount.Text;
            }
        }
 
        /// <summary>
        /// Performs cleanup by closing the browser and releasing resources.
        /// </summary>
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
