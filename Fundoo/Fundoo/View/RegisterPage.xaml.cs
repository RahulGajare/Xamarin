// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterPage.xaml.cs" company="Bridgelabz">
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
    using Fundoo.DependencyServices;
    using Fundoo.FirebaseConnector;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RegisterPage Class
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
     [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
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
            FireBaseThroughAuthentication fireBaseThroughAuthentication = new FireBaseThroughAuthentication();

            if (txtFirstName.Text == null || txtFirstName.Text.Trim().Equals(string.Empty))
            {
                await this.DisplayAlert("Alert", "Required Field", "Ok");
                return;
            }

            bool isRegistered = await fireBaseThroughAuthentication.RegisterUser(txtFirstName.Text, txtLastName.Text, txtUserEmail.Text, txtUserPassWord.Text, txtUserPhoneNumber.Text);
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtUserEmail.Text = string.Empty;
            txtUserPassWord.Text = string.Empty;
            txtConfirmPassWord.Text = string.Empty;
            txtUserPhoneNumber.Text = string.Empty;

            if (isRegistered)
            {
                await this.DisplayAlert("Alert", "Registerd Successfully", "Ok");
            }
            else
            {
                await this.DisplayAlert("Alert", "Email already in used", "Try again");
            }          
        }
    }
}