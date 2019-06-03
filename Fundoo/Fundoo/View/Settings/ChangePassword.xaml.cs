using Fundoo.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fundoo.View.Settings
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangePassword : ContentPage
	{
		public ChangePassword ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
           this.PasswordChange();
                     
        }

        private void PasswordChange()
        {
            ResetPassword resetPassword = new ResetPassword();
              resetPassword.Changepassword(oldPassword.Text, newPassword.Text);

            //if (res)
            //{
            //    await this.DisplayAlert("Alert", "password Changed", "OK");
            //}
            //else
            //{
            //    await this.DisplayAlert("Alert", "Wrong password", "OK");
            //}
        }
    }
}