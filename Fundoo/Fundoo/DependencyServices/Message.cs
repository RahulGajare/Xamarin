// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Message.cs" company="Bridgelabz">
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
    /// Message class
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Shows the toast message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void ShowToastMessage(string message)
        {
            DependencyService.Get<IMessage>().ShowToast(message);
        }
    }
}
