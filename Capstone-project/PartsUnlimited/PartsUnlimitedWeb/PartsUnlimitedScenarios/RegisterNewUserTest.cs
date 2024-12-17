using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsUnlimitedOperations;
using PartsUnlimitedWebAdaptors;

namespace PartsUnlimitedScenarios
{
    [TestFixture]
    public class RegisterNewUserTests
    {
        // Interface for registering a new user.
        IRegisterNewUser registerNewUser;

        [SetUp]
        public void SetUp()
        {
            // Initialize the RegisterNewUser instance before each test.
            registerNewUser = new RegisterNewUser();
        }

        [Test]
        public void TestCreateAccount()
        {
            // Arrange: Set up the expected confirmation message and test credentials.
            string expectedConfirmationMessage = "Demo link display page - Not for production use";
            string userName = "testuser1235@example.com"; // Test username.
            string password = "Password123!"; // Test password.

            // Act: Call the CreateAccount method and retrieve the confirmation message.
            string actualConfirmationMessage = registerNewUser.CreateAccount(userName, password, password);

            // Assert: Verify the confirmation message matches the expected result.
            Assert.AreEqual(expectedConfirmationMessage, actualConfirmationMessage,
                "Account creation failed or confirmation message did not match.");

            // Cleanup: Close the browser and release resources after the test.
            registerNewUser.TearDown();
        }
        [Test]
        public void TestExistingcount()
        {
            // Arrange: Set up the expected confirmation message and test credentials.
            string expectedConfirmationMessage = "Create a new account.";
            string userName = "testuser1235@example.com"; // Test username.
            string password = "Password123!"; // Test password.

            // Act: Call the CreateAccount method and retrieve the confirmation message.
            string actualConfirmationMessage = registerNewUser.CreateAccount(userName, password,password);

            // Assert: Verify the confirmation message matches the expected result.
            Assert.AreEqual(expectedConfirmationMessage, actualConfirmationMessage,
                "Already Existing Account Identifaction was failed");

            // Cleanup: Close the browser and release resources after the test.
            registerNewUser.TearDown();
        }
        [Test]
        public void ValiDateCredentials()
        {
            //Arrange
            string expectedConfirmationMessage = "Create a new account.";
            string userName = "testuser12367859@example.com"; // Test username.
            string password = "Password123!"; // Test password.
            String confirmpassword = "password";

            // Act: Call the CreateAccount method and retrieve the confirmation message.
            string actualConfirmationMessage = registerNewUser.CreateAccount(userName, password,confirmpassword);

            // Assert: Verify the confirmation message matches the expected result.
            Assert.AreEqual(expectedConfirmationMessage, actualConfirmationMessage,
                "Password and Confirm Password mismatch Identifaction was failed");

            //Arrange
            password = "1";
            expectedConfirmationMessage = "Create a new account.";
            //Act:password length must be greater than or equal to 6 it should identify that
            actualConfirmationMessage = registerNewUser.CreateAccount(
                userName, password, password);
            //Assert
            Assert.AreEqual(expectedConfirmationMessage, actualConfirmationMessage,
                "Password length Identifaction was failed");

            // Cleanup: Close the browser and release resources after the test.
            //registerNewUser.TearDown();

        }
    }
}
