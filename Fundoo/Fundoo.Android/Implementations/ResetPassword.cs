using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void UpdatePassword(string oldPassword ,string newPassword)
        {
          var res =  FirebaseAuth.Instance.CurrentUser;
           string email = res.Email;
           
               // await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, oldPassword);
                AuthCredential credential = EmailAuthProvider.GetCredential(email, oldPassword);
               //var task =  res.Reauthenticate(credential);
           var task =   FirebaseAuth.Instance.CurrentUser.ReauthenticateAsync(credential);

            if (task.IsCompletedSuccessfully)
            {
                  FirebaseAuth.Instance.CurrentUser.UpdatePasswordAsync(newPassword);
            }
            else
            {
                
            }



        }

        
    }
}