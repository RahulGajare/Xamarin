// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessage.cs" company="Bridgelabz">
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
    /// IMessage Interface
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Shows the toast.
        /// </summary>
        /// <param name="message">The message.</param>
        void ShowToast(string message);
    }
}
