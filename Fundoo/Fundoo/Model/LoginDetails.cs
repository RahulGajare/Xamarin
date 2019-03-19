using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Model
{
    class LoginDetails
    {
        private string email;
        private string passWord;

        public string Email { get => this.email; set => this.email = value; }
        public string PhoneNumber { get => this.passWord; set => this.passWord = value; }
    }
}
