// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FirebaseAuthenticator.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Fundoo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Firebase.Auth;
   
    using static Fundoo.IFireBaseAuthenticator;

    //public static string PackageName { get; }

    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {       
            public async Task<string> LoginWithEmailPassword(string email, string password)
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }

        public async Task<string> AddUserWithEmailPassword(string email, string password)
        {
            var response = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            //using (var user = response.User)
            //using (var actionCode = ActionCodeSettings.NewBuilder().SetAndroidPackageName(PackageName, true, "0").Build())
            //{
            //    await user.SendEmailVerificationAsync(actionCode);
            //}
            return response.User.Uid;
        }
    }
}
