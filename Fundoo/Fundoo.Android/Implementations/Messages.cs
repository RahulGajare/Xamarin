// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Messages.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

using Fundoo.Droid.Implementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(Messages))]
    
namespace Fundoo.Droid.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget; 
    using Fundoo.Interfaces;

    /// <summary>
    /// Messages Class
    /// </summary>
    /// <seealso cref="Fundoo.Interfaces.IMessage" />
    public class Messages : IMessage
    {
        /// <summary>
        /// Shows the toast.
        /// </summary>
        /// <param name="message">The message.</param>
        public void ShowToast(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}