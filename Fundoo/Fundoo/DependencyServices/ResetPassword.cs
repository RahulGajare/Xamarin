using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Fundoo.Interfaces;

namespace Fundoo.DependencyServices
{
    public class ResetPassword
    {
        public  void Resetpassword(string emailAddress)
        {
            DependencyService.Get<IResetPassword>().SendPassword(emailAddress);
        }
    }
}
