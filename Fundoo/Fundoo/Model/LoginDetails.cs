// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginDetails.cs" company="Bridgelabz">
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
    /// LoginDetails class
    /// </summary>
    public class LoginDetails
    {
        /// <summary>
        /// The email
        /// </summary>
        private string email;

        /// <summary>
        /// The pass word
        /// </summary>
        private string passWord;

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
        public string PhoneNumber { get => this.passWord; set => this.passWord = value; }
    }
}
