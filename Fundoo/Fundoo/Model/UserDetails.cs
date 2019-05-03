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

    /// <summary>
    /// UserDetails class
    /// </summary>
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

        /// <summary>
        /// The profile pic
        /// </summary>
        private string profilePic;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetails"/> class.
        /// </summary>
        public UserDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetails"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="passWord">The pass word.</param>
        /// <param name="phoneNumber">The phone number.</param>
        public UserDetails(string firstName, string lastName, string email, string passWord, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.PassWord = passWord;
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get => this.firstName; set => this.firstName = value; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get => this.lastName; set => this.lastName = value; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get => this.email; set => this.email = value; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get => this.phoneNumber; set => this.phoneNumber = value; }

        /// <summary>
        /// Gets or sets the pass word.
        /// </summary>
        /// <value>
        /// The pass word.
        /// </value>
        public string PassWord { get => this.passWord; set => this.passWord = value; }

        /// <summary>
        /// Gets or sets the profile pic.
        /// </summary>
        /// <value>
        /// The profile pic.
        /// </value>
        public string ProfilePic { get => profilePic; set => profilePic = value; }
    }
}
