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

    public class FireBaseAuthenticator : IFirebaseAuthenticator
    {

        public async Task<bool> LoginWithEmailPassword(string email, string password)
        {
            var result = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var user = result.User.Uid;
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> RegisterUserWithEmailPassword(string email, string password)
        {
            var response = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

            return response.User.Uid;
        }
    }
}