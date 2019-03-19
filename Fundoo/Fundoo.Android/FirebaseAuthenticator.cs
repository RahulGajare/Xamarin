
namespace Fundoo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Firebase.Auth;
   
    using static Fundoo.IFireBaseAuthenticator;

    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        
            public async Task<string> LoginWithEmailPassword(string email, string password)
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }      
    }
}
