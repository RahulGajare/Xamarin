// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Greeting.xaml.cs" company="Bridgelabz">
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
    using Fundoo.DependencyServices;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Greeting class
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Greeting : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Greeting"/> class.
        /// </summary>
        public Greeting()
        {     
                this.InitializeComponent();

            this.BindingContext = this;
            this.IsBusy = false;
          
                var tapImage = new TapGestureRecognizer();
                //// Binding events    
                tapImage.Tapped += this.TapImage_Tapped;
                ///// Associating tap events to the image buttons    
                googleIcon.GestureRecognizers.Add(tapImage);   
        }

        /// <summary>
        /// Handles the Tapped event of the tapImage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
       public void TapImage_Tapped(object sender, EventArgs e)
        {
            //// handles the tap over google icon   
            this.DisplayAlert("Alert", "This is an image button", "OK");
        }

        /// <summary>
        /// Handles the Clicked event of the LoginUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Login_Clicked(object sender, EventArgs e)
        {
            this.IsBusy = true;

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
                    Page fundooNotes = new FundooNotes();

                    await Navigation.PushAsync(fundooNotes);               
                    
                   //// NavigationPage.SetHasNavigationBar(fundooNotes, true);
                }
                else
                {
                    Message.ShowToastMessage("Login failed");
                }
            }
            catch (Exception)
            {
                Message.ShowToastMessage("Exception failed");
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

        /// <summary>
        /// Handles the Clicked event of the ForgotPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgotPassword());
        }
    }
}