using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PartsUnlimitedWebAdaptors;
using PartsUnlimitedOperations;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;

namespace PartsUnlimitedScenarios
{
    [TestFixture]
    public class LogInPageTests
    {
        ILogInPage login;

        [SetUp]
        public void SetUp()
        {
            // Initialize the LogInPage object before each test
            login = new LogInPage();
        }

        [Test]
        public void TestLogInWithValidCredentials()
        {
            // Arrange: Define valid username, password, and expected URL
            string username = "logesh.s@ascendion.com";
            string password = "Logesh@16";
            String Expected = "http://localhost:5001/";

            // Act: Perform the login action
            string currentUrl = login.LogIn(username, password, false);

            // Assert: Verify if the URL matches the expected URL after login
            Assert.AreEqual(Expected, currentUrl, "Login failed with valid credentials.");

            // TearDown: Clean up after the test
            login.TearDown();
        }

        [Test]
        public void TestLogInWithInValidCredentials()
        {
            // Arrange: Define invalid password and expected URL
            string username = "logesh.s@ascendion.com";
            string password = "Logesh@136";
            String Expected = "http://localhost:5001/";

            // Act: Attempt login with invalid credentials
            string currentUrl = login.LogIn(username, password, false);

            // Assert: Ensure the URL does not match the expected URL
            Assert.AreNotEqual(Expected, currentUrl, "Login functionality failure with invalid credentials.");

            // TearDown: Clean up after the test
            login.TearDown();
        }

        [Test]
        public void TestForgotPassword()
        {
            // Arrange: Define the username for password recovery
            string username = "logesh.s@ascendion.com";

            // Act: Trigger the forgot password functionality
            String confirmationMessage = login.ForgotPassword(username);

            // Assert: Verify the confirmation message matches the expected text
            Assert.AreEqual("Demo link display page - Not for production use", confirmationMessage, "Forgot password process failed.");

            // TearDown: Clean up after the test
            login.TearDown();
        }

        [Test]
        public void TestRememberMeFunctionality()
        {
            // Act: Perform the Remember Me functionality test
            bool isRemembered = login.RemeberMe();

            // Assert: Verify that the credentials are remembered
            Assert.IsTrue(isRemembered, "Remember Me functionality failed.");

            // TearDown: Clean up after the test
            login.TearDown();
        }
        [Test]
        public void TestOtherSignin()
        {
            // Arrange
            string expectedUrl = "https://learn.microsoft.com/en-us/aspnet/mvc/overview/security/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on"; 
            // Act
            String currentUrl=login.OtherSignin(); // Call the method to perform the "Other Sign-In" action and Get the current URL after the action.
            // Assert
            Assert.AreEqual(expectedUrl, currentUrl, "Other sign-in functionality failed to navigate to the expected URL.");
        }


        [Test]
        public void TestNavigateToRegisterNewUser()
        {
            // Act: Navigate to the Register New User page
            string registerUrl = login.NavigateToRegisterNewUser();

            // Assert: Verify the navigation URL matches the expected registration URL
            Assert.AreEqual("http://localhost:5001/Account/Register", registerUrl, "Navigation to Register New User failed.");

            // TearDown: Clean up after the test
            login.TearDown();
        }
    }
}
