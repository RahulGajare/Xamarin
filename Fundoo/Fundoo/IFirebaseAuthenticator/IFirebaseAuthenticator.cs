// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFirebaseAuthenticator.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Fundoo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// IFireBaseAuthenticator class
    /// </summary>
    public class IFireBaseAuthenticator
    {
        /// <summary>
        /// IFirebaseAuthenticator Interface
        /// </summary>
        public interface IFirebaseAuthenticator
        {
            Task<string> LoginWithEmailPassword(string email, string password);
            Task<string> AddUserWithEmailPassword(string email, string password);
        }
    }
}
