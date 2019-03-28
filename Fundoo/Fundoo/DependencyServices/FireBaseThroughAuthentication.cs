// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FireBaseThroughAuthentication.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.DependencyServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Firebase.Database;
    using Firebase.Database.Query;
    using Fundoo.Interfaces;
    using Fundoo.Model;  
    using Xamarin.Forms;

    /// <summary>
    /// FireBaseThroughAuthentication class
    /// </summary>
    public class FireBaseThroughAuthentication : ContentPage
    {
        /// <summary>
        /// The firebase client
        /// </summary>
        private FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>returns User id</returns>
        public async Task<bool> RegisterUser(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            var uid = await DependencyService.Get<IFirebaseAuthenticator>().RegisterUserWithEmailPassword(email, password);
            if (uid != null)
            {
                await this.firebaseClient.Child("FundooUsers").Child(uid).Child("Userinfo").PostAsync<UserDetails>(new UserDetails() { FirstName = firstName, LastName = lastName, Email = email, PassWord = password, PhoneNumber = phoneNumber });
                return true;
            }

            return false;
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>returns true or false</returns>
        public async Task<bool> LoginUser(string email, string password)
        {
           bool isLoggedIn = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(email, password);
            return isLoggedIn;
        }

        public  bool CheckStatus()
        {
           var isLoggedIn =  DependencyService.Get<IFirebaseAuthenticator>().IsLoggedin();

            return isLoggedIn;

        }

        public void LogOut()
        {
            DependencyService.Get<IFirebaseAuthenticator>().Signout();
        }

    }
}
