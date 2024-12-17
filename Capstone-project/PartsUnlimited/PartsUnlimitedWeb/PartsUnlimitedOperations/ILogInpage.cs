using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PartsUnlimitedOperations
{
    /// <summary>
    /// Interface defining operations related to user authentication.
    /// </summary>
    public interface ILogInPage
    {
        /// <summary>
        /// Performs the login operation using the provided username and password.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <param name="remberMe">Indicates whether the "Remember Me" checkbox should be selected.</param>
        /// <returns>The URL of the page after the login operation is completed.</returns>
        public String LogIn(string username, string password, bool remberMe);

        /// <summary>
        /// Toggles the "Remember Me" checkbox functionality and verifies if credentials are remembered.
        /// </summary>
        /// <returns>True if credentials are remembered successfully; otherwise, false.</returns>
        public bool RemeberMe();

        /// <summary>
        /// Redirects to the registration page for creating a new user account.
        /// </summary>
        /// <returns>The URL of the registration page.</returns>
        public String NavigateToRegisterNewUser();

        /// <summary>
        /// Redirects to the password recovery process for users who forgot their password.
        /// </summary>
        /// <param name="username">The username or email of the user requesting a password reset.</param>
        /// <returns>A confirmation message indicating the status of the password recovery process.</returns>
        public String ForgotPassword(String username);

        /// <summary>
        /// Handles alternative sign-in methods (e.g., Google, Facebook, or other third-party providers).
        /// </summary>
        public String OtherSignin();

        /// <summary>
        /// Performs cleanup operations, such as closing the browser or releasing resources.
        /// </summary>
        public void TearDown();
    }
}

