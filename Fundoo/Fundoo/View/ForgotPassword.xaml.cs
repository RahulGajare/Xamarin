using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fundoo.DependencyServices;

namespace Fundoo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPassword : ContentPage
	{
		public ForgotPassword()
		{
			InitializeComponent();
		}

        private async void TxtResetPassword_Clicked(object sender, EventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Resetpassword(txtEmailAddress.Text);
            await DisplayAlert("Alert", "password sent to your mail", "OK");
        }
    }
}