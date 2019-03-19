﻿
namespace Fundoo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class IFireBaseAuthenticator
    {
        public interface IFirebaseAuthenticator
        {
            Task<string> LoginWithEmailPassword(string email, string password);
        }
    }
}
