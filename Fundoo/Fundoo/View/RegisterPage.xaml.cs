using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Fundoo.FirebaseConnector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fundoo.View
{

    public partial class RegisterPage : ContentPage
    {
        FireBaseConnector fireBaseConnector = new FireBaseConnector();


        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void FormSubmit_Clicked(object sender, EventArgs e)
        {
            if (txtFirstName.Text == null || txtFirstName.Text.Trim().Equals(string.Empty))
            {
                await this.DisplayAlert("Alert", "Required Field", "Ok");
            }

            await fireBaseConnector.AddUserDetails(txtFirstName.Text, txtLastName.Text, txtUserEmail.Text, txtUserPassWord.Text, txtUserPhoneNumber.Text);
            await DisplayAlert("Alert", "Registered Succesfully", "Ok");
        }
    }
}