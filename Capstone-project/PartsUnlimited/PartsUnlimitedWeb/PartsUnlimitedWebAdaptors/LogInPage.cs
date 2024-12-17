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
    /// <summary>
    /// Class for handling login page interactions.
    /// </summary>
    public class LogInPage : PartsUnlimitedCommon, ILogInPage
    {
        /// <summary>
        /// Default constructor that navigates to the login page URL.
        /// </summary>
        public LogInPage() : base()
        {
            driver.Navigate().GoToUrl("http://localhost:5001/Account/Login");
        }

        /// <summary>
        /// Constructor with an existing IWebDriver instance that navigates to the login page URL.
        /// </summary>
        /// <param name="driver">Instance of IWebDriver.</param>
        public LogInPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl("http://localhost:5001/Account/Login");
        }

        /// <summary>
        /// Handles the "Forgot Password" functionality by entering the username and submitting the request.
        /// </summary>
        /// <param name="username">The username or email for password recovery.</param>
        /// <returns>A confirmation message indicating the success of the password recovery process.</returns>
        public String ForgotPassword(String username)
        {
            // Click on the "Forgot your password?" link
            IWebElement ForgotPass = driver.FindElement(By.XPath("//a[normalize-space()='Forgot your password?']"));
            ForgotPass.Click();

            // Enter the email/username in the password recovery field
            IWebElement Email = driver.FindElement(By.XPath("//input[@id='Email']"));
            Email.SendKeys(username);

            // Click on the "Email Link" button to send the recovery email
            IWebElement SendLink = driver.FindElement(By.XPath("//input[@value='Email Link']"));
            SendLink.Click();

            // Retrieve and return the confirmation message
            String PasswordReset = driver.FindElement(By.XPath("//h2[normalize-space()='Demo link display page - Not for production use']")).Text;
            return PasswordReset;
        }

        /// <summary>
        /// Navigates to the "Register New User" page.
        /// </summary>
        /// <returns>The URL of the registration page.</returns>
        public String NavigateToRegisterNewUser()
        {
            // Find and click on the "Register as a new user" link
            IWebElement navigate = driver.FindElement(By.XPath("//a[normalize-space()='Register as a new user']"));
            navigate.Click();

            // Return the current URL after navigation
            return driver.Url;
        }

        /// <summary>
        /// Verifies the "Remember Me" functionality by attempting to log in with saved credentials.
        /// </summary>
        /// <returns>True if the "Remember Me" feature works; otherwise, false.</returns>
        public bool RemeberMe()
        {
            // Log in with valid credentials and enable "Remember Me"
            String url = LogIn("logesh.s@ascendion.com", "Logesh@16", true);

            // Navigate to the user profile
            IWebElement profile = driver.FindElement(By.XPath("//a[@id='profile-link']"));
            profile.Click();

            // Log off and return to the login page
            IWebElement LoggOff = driver.FindElement(By.XPath("//a[normalize-space()='Log off']"));
            LoggOff.Click();
            driver.Navigate().GoToUrl("http://localhost:5001/Account/Login");

            // Verify if the email and password fields are pre-filled
            String Email = driver.FindElement(By.XPath("//input[@id='Email']")).Text;
            String Password = driver.FindElement(By.XPath("//input[@id='Password']")).Text;

            if (Email.Length != 0 && Password.Length != 0)
            {
                // If pre-filled, attempt to log in again
                IWebElement LogInButton = driver.FindElement(By.XPath("//input[@value='Login']"));
                LogInButton.Click();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Enters the provided username and password into their respective input fields.
        /// </summary>
        /// <param name="username">The username to be entered.</param>
        /// <param name="password">The password to be entered.</param>
        private void EnterCredentials(String username, String password)
        {
            // Enter the email into the input field
            IWebElement Email = driver.FindElement(By.XPath("//input[@id='Email']"));
            Email.SendKeys(username);

            // Enter the password into the input field
            IWebElement Password = driver.FindElement(By.XPath("//input[@id='Password']"));
            Password.SendKeys(password);
        }

        /// <summary>
        /// Logs in the user with the provided credentials and optional "Remember Me" selection.
        /// </summary>
        /// <param name="username">The username to be entered.</param>
        /// <param name="password">The password to be entered.</param>
        /// <param name="remeberMe">Flag indicating if "Remember Me" should be selected.</param>
        /// <returns>The URL of the page after login.</returns>
        public String LogIn(string username, string password, bool remeberMe)
        {
            // Enter username and password
            EnterCredentials(username, password);

            // Select the "Remember Me" checkbox if required
            if (remeberMe)
            {
                IWebElement checkBox = driver.FindElement(By.XPath("//input[@id='RememberMe']"));
                checkBox.Click();
            }

            // Click the login button
            IWebElement LogInButton = driver.FindElement(By.XPath("//input[@value='Login']"));
            LogInButton.Click();

            // Return the current URL after login
            return driver.Url;
        }
        /// <summary>
        /// Navigates to an alternative sign-in option by clicking the specified link.
        /// </summary>
        public String OtherSignin()
        {
            IWebElement OtherOption = driver.FindElement(By.XPath("//a[normalize-space()='this article']"));
            OtherOption.Click();
            return driver.Url;
        }
        /// <summary>
        /// Cleans up the browser session by closing the driver.
        /// </summary>
        public void TearDown()
        {
            driver.Quit();
        }

     
    }
}

