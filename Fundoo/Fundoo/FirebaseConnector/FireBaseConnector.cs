using Fundoo.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Fundoo.FirebaseConnector
{
    public class FireBaseConnector
    {
         FirebaseClient firebaseClient = new FirebaseClient("https://fundoousers-a9d30.firebaseio.com/");

        public async Task<List<UserDetails>> GetAllUserDetails()
        {

            return (await firebaseClient
              .Child("RegisterDetails")
              .OnceAsync<UserDetails>()).Select(item => new UserDetails
              {
                  FirstName = item.Object.FirstName,
                  LastName = item.Object.LastName,
                  Email = item.Object.Email,
                  PassWord = item.Object.PassWord,
                  PhoneNumber = item.Object.PhoneNumber
              }).ToList();
        }

        public async Task AddUserDetails(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            await this.firebaseClient
              .Child("RegisterDetails")
              .PostAsync(new UserDetails(firstName, lastName, email, password, phoneNumber));
        }


        public async Task<UserDetails> GetUserDetail(string email)
        {
            var registeredDetails = await GetAllUserDetails();
            await this.firebaseClient
              .Child("RegisterDetails")
              .OnceAsync<UserDetails>();
            return registeredDetails.Where(a => a.Email.Equals(email)).FirstOrDefault();
        }
    }
}
