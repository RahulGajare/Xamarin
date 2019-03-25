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
using Firebase.Auth;

namespace Fundoo.Droid.Implementations
{
    class ResetPassword
    {
        public void SendPassword(string emailAddress)
        {
            FirebaseAuth auth = FirebaseAuth.Instance;
            auth.SendPasswordResetEmailAsync(emailAddress);
        }
      
    }
}