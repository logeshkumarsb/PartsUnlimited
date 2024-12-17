using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimitedOperations
{
    /// <summary>
    /// Interface defining operations for registering a new user.
    /// </summary>
    public interface IRegisterNewUser
    {
        /// <summary>
        /// Creates a new user account with the provided username and password.
        /// </summary>
        /// <param name="UserName">The username for the new account.</param>
        /// <param name="Password">The password for the new account.</param>
        /// <returns>A confirmation message indicating the result of the account creation.</returns>
        public String CreateAccount(String UserName, String Password,String ConfirmPassword);

        /// <summary>
        /// Cleans up resources or performs teardown operations after completing actions.
        /// </summary>
        public void TearDown();
    }
}
