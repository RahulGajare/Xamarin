// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IResetPassword.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// IResetPassword Class
    /// </summary>
    public interface IResetPassword
    {
        /// <summary>
        /// Sends the password.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        void SendPassword(string emailAddress);
    }
}
