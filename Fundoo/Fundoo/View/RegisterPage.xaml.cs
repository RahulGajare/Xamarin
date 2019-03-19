// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Firebase.Database;
    using Fundoo.FirebaseConnector;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public partial class RegisterPage : ContentPage
    {
        public FireBaseConnector fireBaseConnector = new FireBaseConnector();


        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private async void FormSubmit_Clicked(object sender, EventArgs e)
        {
            if (txtFirstName.Text == null || txtFirstName.Text.Trim().Equals(string.Empty))
            {
                await this.DisplayAlert("Alert", "Required Field", "Ok");
            }

            await this.fireBaseConnector.AddUserDetails(txtFirstName.Text, txtLastName.Text, txtUserEmail.Text, txtUserPassWord.Text, txtUserPhoneNumber.Text);
            await this.DisplayAlert("Alert", "Registered Succesfully", "Ok");
        }
    }
}