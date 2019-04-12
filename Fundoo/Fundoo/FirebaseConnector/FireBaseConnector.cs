﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FireBaseConnector.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.FirebaseConnector
{
    using System.Collections.Generic;
     using System.Linq;
    using System.Threading.Tasks;
    using Firebase.Database;
    using Firebase.Database.Query;    
    using Fundoo.Model;  
    using Newtonsoft.Json;
 
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
        /// <returns> Returns List of User Details</returns>
        public async Task<List<UserDetails>> GetAllUserDetails()
        {
            FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");
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

        /// <summary>
        /// Adds the user details.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>returns Task</returns>
        public async Task AddUserDetails(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            await this.firebaseClient
              .Child("RegisterDetails")
              .PostAsync(new UserDetails(firstName, lastName, email, password, phoneNumber));
        }

        /// <summary>
        /// Gets the user detail.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns the User info that matches the criteria</returns>
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
