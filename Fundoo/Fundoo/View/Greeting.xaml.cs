// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Greeting.xaml.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.View
{
    using Fundoo.DependencyServices;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// FirstPage class
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstPage"/> class.
        /// </summary>
        public FirstPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the LoginUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (txtEmail.Text == null || txtEmail.Text.Trim().Equals(string.Empty))
            {
                await this.DisplayAlert("Alert", "Email should be specified", "Ok");
                return;
            }

            if (txtPassWord.Text == null || txtPassWord.Text.Trim().Equals(string.Empty))
            {
                await this.DisplayAlert("Alert", "Password not Specified", "Ok");
                return;
            }

            try
            {

                FireBaseThroughAuthentication fireBaseThoroughAuthentication = new FireBaseThroughAuthentication();
                bool isLoggedIn = await fireBaseThoroughAuthentication.LoginUser(txtEmail.Text, txtPassWord.Text);

                if (isLoggedIn)
                {
                    Message.ShowToastMessage("LoggedIn successfully");
                    await Navigation.PushModalAsync(new HomePage());
                }
                else
                {
                    Message.ShowToastMessage("Login failed");
                }
            }
            catch (Exception)
            {
                Message.ShowToastMessage("Login failed");
            }
        }

        /// <summary>
        /// Handles the Clicked event of the RegisterUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegisterPage());
        }

        private async void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgotPassword());
        }
    }
}