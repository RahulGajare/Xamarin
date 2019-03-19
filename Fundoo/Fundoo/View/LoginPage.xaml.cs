using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundoo.FirebaseConnector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fundoo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{

        FireBaseConnector fireBaseConnector = new FireBaseConnector();

        public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var registerDetails = await fireBaseConnector.GetUserDetail(txtEmail.Text);

            if (registerDetails != null)
            {
                if (registerDetails.PassWord.Equals(txtPassWord.Text))
                {
                    await this.DisplayAlert("Alert", "Login Successful", "Ok");
                }
                else
                {
                    await this.DisplayAlert("Alert", "Login Failed", "try again");
                }
            }
            else
            {
                await this.DisplayAlert("Alert", "Email not Registered", "try again");
            }
        }
    }
}