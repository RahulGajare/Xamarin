// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetPassword.cs" company="Bridgelabz">
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
    using Fundoo.Interfaces;
    using Xamarin.Forms;

    /// <summary>
    /// ResetPassword Class
    /// </summary>
    public class ResetPassword
    {
        /// <summary>
        /// Reset passwords the specified email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        public void Resetpassword(string emailAddress)
        {
            DependencyService.Get<IResetPassword>().SendPassword(emailAddress);
        }

        public  void Changepassword(string oldPassword ,string newPassword)
        {
             DependencyService.Get<IResetPassword>().UpdatePassword(oldPassword,newPassword);
            
        }
    }
}
