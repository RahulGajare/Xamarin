// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFireBaseAuthenticator.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// IFirebaseAuthenticator Interface
    /// </summary>
    public interface IFirebaseAuthenticator
        {
        /// <summary>
        /// Logins the with email password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>returns true or false</returns>
        Task<bool> LoginWithEmailPassword(string email, string password);

        /// <summary>
        /// Registers the user with email password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>returns User id</returns>
        Task<string> RegisterUserWithEmailPassword(string email, string password);

        /// <summary>
        /// Determines whether this instance is logged in.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is logged in; otherwise, <c>false</c>.
        /// </returns>
        bool IsLoggedin();

        /// <summary>
        /// Sign outs this instance.
        /// </summary>
        void Signout();
    }   
}
