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
    public interface ILogIn
    {
        /// <summary>
        /// Performs the login operation using the provided username and password.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        public void LogIn(string username, string password);

        /// <summary>
        /// Toggles the "Remember Me" checkbox functionality.
        /// </summary>
        /// <returns>True if the checkbox is toggled, otherwise false.</returns>
        public bool RemeberMeChechBox();

        /// <summary>
        /// Redirects to the registration page for creating a new user account.
        /// </summary>
        public void RegisterNewUser();

        /// <summary>
        /// Redirects to the password recovery process for users who forgot their password.
        /// </summary>
        public void ForgotPassword();
    }
}
