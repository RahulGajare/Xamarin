// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FireBaseAuthenticator.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

using Fundoo.Droid.Implementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(FireBaseAuthenticator))]

namespace Fundoo.Droid.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Firebase.Auth;
    using Fundoo.Interfaces;

    /// <summary>
    /// FireBaseAuthenticator Class
    /// </summary>
    /// <seealso cref="Fundoo.Interfaces.IFirebaseAuthenticator" />
    public class FireBaseAuthenticator : IFirebaseAuthenticator
    {
        public string GetUid()
        {
            return  FirebaseAuth.Instance.CurrentUser.Uid;
        }

        public bool IsLoggedin()
        {
            var status = FirebaseAuth.Instance.CurrentUser;

            if (status != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Logins the with email password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>Returns true or false</returns>
        public async Task<bool> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception )
            {
                return false;
            }         
        }

        /// <summary>
        /// Registers the user with email password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>returns string</returns>
        public async Task<string> RegisterUserWithEmailPassword(string email, string password)
        {
            try
            {
                var response = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                return response.User.Uid;
            }
            catch (Exception)
            {             
                return null;
            }      
        }

        public void Signout()
        {
            FirebaseAuth.Instance.SignOut();
        }
    }
}