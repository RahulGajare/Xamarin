// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

   public class LoginDetails
    {
        private string email;
        private string passWord;

        public string Email { get => this.email; set => this.email = value; }
        public string PhoneNumber { get => this.passWord; set => this.passWord = value; }
    }
}
