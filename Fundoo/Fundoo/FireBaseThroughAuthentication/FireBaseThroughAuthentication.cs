using Firebase.Database;
using Firebase.Database.Query;
using Fundoo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Fundoo.IFireBaseAuthenticator;

namespace Fundoo.FireBaseThoroughAuthentication
{
    class FireBaseThroughAuthentication
    {
        private FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        public async Task<string> AddUserAsync(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            string uid = await DependencyService.Get<IFirebaseAuthenticator>().AddUserWithEmailPassword(email, password);
            if (uid != null)
            {
                await firebaseClient.Child("FundooUsers").Child(uid).Child("Userinfo").PostAsync<UserDetails>(new UserDetails() { FirstName = firstName, LastName = lastName });
            }

            return uid;
        }
    }
}
