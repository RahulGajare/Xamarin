﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Fundoo.Droid.Implementations;
using Fundoo.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(ResetPassword))]
namespace Fundoo.Droid.Implementations
{
    public class ResetPassword : IResetPassword
    {
        public void SendPassword(string emailAddress)
        {
            FirebaseAuth.Instance.SendPasswordResetEmail(emailAddress);
        }
    }
}