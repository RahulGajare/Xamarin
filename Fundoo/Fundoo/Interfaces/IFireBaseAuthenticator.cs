using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fundoo.Interfaces
{
   
     public interface IFirebaseAuthenticator
        {
            Task<bool> LoginWithEmailPassword(string email, string password);
            Task<string> RegisterUserWithEmailPassword(string email, string password);
        }
    
}
