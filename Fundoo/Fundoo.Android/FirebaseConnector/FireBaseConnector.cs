// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FireBaseConnector.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.FirebaseConnector
{ 
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using Fundoo.Model;
    using Firebase.Database;
    using Firebase.Database.Query;
    using Newtonsoft.Json;
    using Firebase.Auth;

    /// <summary>
    /// FireBaseConnector class
    /// </summary>
    public class FireBaseConnector
    {
        /// <summary>
        /// The firebase client
        /// </summary>
        private FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        /// <summary>
        /// Gets all user details.
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserDetails>> GetAllUserDetails()
        {
            return (await this.firebaseClient
              .Child("RegisterDetails")
              .OnceAsync<UserDetails>()).Select(item => new UserDetails
              {
                  FirstName = item.Object.FirstName,
                  LastName = item.Object.LastName,
                  Email = item.Object.Email,
                  PassWord = item.Object.PassWord,
                  PhoneNumber = item.Object.PhoneNumber
              }).ToList();
        }

       
        public async Task<string> AddUserWithEmailPassword(string email, string password)
        {
            var response = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            //using (var user = response.User)
            //using (var actionCode = ActionCodeSettings.NewBuilder().SetAndroidPackageName(PackageName, true, "0").Build())
            //{
            //    await user.SendEmailVerificationAsync(actionCode);
            //}
            return response.User.Uid;
        }

        /// <summary>
        /// Gets the user detail.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<UserDetails> GetUserDetail(string email)
        {
            var registeredDetails = await this.GetAllUserDetails();
            await this.firebaseClient
              .Child("RegisterDetails")
              .OnceAsync<UserDetails>();
            return registeredDetails.Where(a => a.Email.Equals(email)).FirstOrDefault();
        }
    }
}
