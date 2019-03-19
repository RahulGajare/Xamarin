using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Model
{
    public class UserDetails
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string passWord;

        public UserDetails()
        {
        }

        public UserDetails(string firstName, string lastName, string email, string passWord, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.PassWord = passWord;
        }

        public string FirstName { get => this.firstName; set => this.firstName = value; }
        public string LastName { get => this.lastName; set => this.lastName = value; }
        public string Email { get => this.email; set => this.email = value; }
        public string PhoneNumber { get => this.phoneNumber; set => this.phoneNumber = value; }
        public string PassWord { get => this.passWord; set => this.passWord = value; }
    }
}
