// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDetails.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserDetails
    {
        /// <summary>
        /// The first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// The email
        /// </summary>
        private string email;

        /// <summary>
        /// The phone number
        /// </summary>
        private string phoneNumber;

        /// <summary>
        /// The pass word
        /// </summary>
        private string passWord;

        public UserDetails()
        {
        }

        public UserDetails(string firstName, string lastName, string email, string passWord, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.PassWord = passWord;
        }

        public string FirstName { get => this.firstName; set => this.firstName = value; }
        public string LastName { get => this.lastName; set => this.lastName = value; }
        public string Email { get => this.email; set => this.email = value; }
        public string PhoneNumber { get => this.phoneNumber; set => this.phoneNumber = value; }
        public string PassWord { get => this.passWord; set => this.passWord = value; }
    }
}
