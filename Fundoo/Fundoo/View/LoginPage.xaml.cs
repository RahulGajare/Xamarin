// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginPage.xaml.cs" company="Bridgelabz">
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
    using Fundoo.FirebaseConnector;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Fundoo.DependencyServices;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        /// <summary>
        /// The fire base connector
        /// </summary>
        private FireBaseConnector fireBaseConnector = new FireBaseConnector();

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            FireBaseThroughAuthentication fireBaseThoroughAuthentication = new FireBaseThroughAuthentication();
            bool isLoggedIn = await fireBaseThoroughAuthentication.LoginUser(txtEmail.Text, txtPassWord.Text);

            if (isLoggedIn)
            {
                Message.ShowToastMessage("LoggedIn successfully");
            }
            else
            {
                Message.ShowToastMessage("Login failed");
            }

            
        }
    }
}