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
        /// <summary>
        /// The fire base connector
        /// 
        /// </summary>
        public FireBaseConnector fireBaseConnector = new FireBaseConnector();

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterPage"/> class.
        /// </summary>
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the FormSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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