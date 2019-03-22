


namespace Fundoo.DependencyServices
{
    using Firebase.Database;
    using Firebase.Database.Query;
    using Fundoo.Interfaces;
    using Fundoo.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    /// <summary>
    /// FireBaseThroughAuthentication class
    /// </summary>
    public class FireBaseThroughAuthentication
    {
       private FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns></returns>
        public async Task<string> RegisterUser(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            string uid = await DependencyService.Get<IFirebaseAuthenticator>().RegisterUserWithEmailPassword(email, password);
            if (uid != null)
            {
                await this.firebaseClient.Child("FundooUsers").Child(uid).Child("Userinfo").PostAsync<UserDetails>(new UserDetails() { FirstName = firstName, LastName = lastName, Email = email, PassWord = password, PhoneNumber = phoneNumber });
            }

            return uid;
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<bool> LoginUser(string email, string password)
        {
           bool isLoggedIn = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(email, password);
            return isLoggedIn;
        }
    }
}
